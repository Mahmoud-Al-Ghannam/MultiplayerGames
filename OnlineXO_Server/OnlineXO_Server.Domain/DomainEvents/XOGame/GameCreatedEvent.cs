using System;
using OnlineXO_Server.Domain.Abstractions;

namespace OnlineXO_Server.Domain.DomainEvents.XOGame;

public class GameCreatedEvent : DomainEvent
{
    public string GameId { get; }
    public string? PlayerXId { get; }
    public string? PlayerOId { get; }

    public GameCreatedEvent(string gameId, string? playerXId, string? playerOId)
    {
        GameId = gameId;
        PlayerXId = playerXId;
        PlayerOId = playerOId;
    }
}
