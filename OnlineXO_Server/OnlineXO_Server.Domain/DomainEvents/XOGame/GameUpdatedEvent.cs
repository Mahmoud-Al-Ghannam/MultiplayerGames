using System;

namespace OnlineXO_Server.Domain.DomainEvents.XOGame;

public class GameUpdatedEvent : DomainEvent
{
    public string GameId { get; } = string.Empty;

    public GameUpdatedEvent(string gameId)
    {
        GameId = gameId;
    }
}
