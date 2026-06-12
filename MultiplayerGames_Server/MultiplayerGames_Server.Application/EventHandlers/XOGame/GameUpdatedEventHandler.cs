using System;
using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Broadcasters.XOGame;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Domain.DomainEvents.XOGame;

namespace MultiplayerGames_Server.Application.EventHandlers.XOGame;

public class GameUpdatedEventHandler : INotificationHandler<GameUpdatedEvent>
{
    private readonly IXOGameBroadcaster _xOGameBroadcaster;
    private readonly IUnitOfWork _unitOfWork;

    public GameUpdatedEventHandler(IXOGameBroadcaster xOGameBroadcaster, IUnitOfWork unitOfWork)
    {
        _xOGameBroadcaster = xOGameBroadcaster;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(GameUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var game = await _unitOfWork.XOGames.GetByIdAsync(notification.GameId, cancellationToken);
        if (game == null)
            return;

        User? playerX =
            game.PlayerXId == null
                ? null
                : await _unitOfWork.Users.GetByIdAsync(game.PlayerXId, cancellationToken);

        User? playerO =
            game.PlayerOId == null
                ? null
                : await _unitOfWork.Users.GetByIdAsync(game.PlayerOId, cancellationToken);

        var gameDto = new GameDto(game, playerX?.Username, playerO?.Username);

        await _xOGameBroadcaster.GameUpdatedAsync(gameDto, cancellationToken);
    }
}
