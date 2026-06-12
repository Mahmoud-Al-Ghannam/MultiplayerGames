using System;
using MediatR;
using OnlineXO_Server.Application.Abstractions.Data;
using OnlineXO_Server.Application.Broadcasters.XOGame;
using OnlineXO_Server.Domain.Aggregates.User;
using OnlineXO_Server.Domain.DomainEvents.XOGame;

namespace OnlineXO_Server.Application.EventHandlers.XOGame;

public class GameStartedEventHandler : INotificationHandler<GameStartedEvent>
{
    private readonly IXOGameBroadcaster _xOGameBroadcaster;
    private readonly IUnitOfWork _unitOfWork;

    public GameStartedEventHandler(IXOGameBroadcaster xOGameBroadcaster, IUnitOfWork unitOfWork)
    {
        _xOGameBroadcaster = xOGameBroadcaster;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(GameStartedEvent notification, CancellationToken cancellationToken)
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
