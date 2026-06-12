using System;
using OnlineXO_Server.Domain.Abstractions;

namespace OnlineXO_Server.Domain.DomainEvents.XOGame;

public class GameStartedEvent : DomainEvent
{
    public string GameId { get; }

    public GameStartedEvent(string gameId)
    {
        GameId = gameId;
    }
}
