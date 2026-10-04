using System;
using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Broadcasters.XOGame;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Domain.DomainEvents.XOGame;

namespace MultiplayerGames_Server.Application.EventHandlers.XOGame;

public class GameCreatedEventHandler : INotificationHandler<XOGameCreatedEvent>
{
    private readonly IXOGameBroadcaster _xOGameBroadcaster;
    private readonly IUnitOfWork _unitOfWork;

    public GameCreatedEventHandler(IXOGameBroadcaster xOGameBroadcaster, IUnitOfWork unitOfWork)
    {
        _xOGameBroadcaster = xOGameBroadcaster;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(XOGameCreatedEvent notification, CancellationToken cancellationToken)
    {
        var game = await _unitOfWork.XOGames.GetByIdAsync(notification.GameId, cancellationToken);
        if (game == null)
            return;

        User? player1 =
            game.Player1Id == null
                ? null
                : await _unitOfWork.Users.GetByIdAsync(game.Player1Id, cancellationToken);

        User? player2 =
            game.Player2Id == null
                ? null
                : await _unitOfWork.Users.GetByIdAsync(game.Player2Id, cancellationToken);

        var gameDto = new GameDto(game, player1?.Username, player2?.Username);

        await _xOGameBroadcaster.GameCreatedAsync(gameDto, cancellationToken);
    }
}
