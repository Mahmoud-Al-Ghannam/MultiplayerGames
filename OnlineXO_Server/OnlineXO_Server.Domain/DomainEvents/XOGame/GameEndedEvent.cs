using System;
using OnlineXO_Server.Domain.Abstractions;
using OnlineXO_Server.Domain.Aggregates.XOGame;

namespace OnlineXO_Server.Domain.DomainEvents.XOGame;

public class GameEndedEvent : DomainEvent
{
    public string GameId { get; }
    public Mark? Winner { get; }
    public string? WinnerId { get; }

    public GameEndedEvent(string gameId, Mark? winner, string? winnerId)
    {
        GameId = gameId;
        Winner = winner;
        WinnerId = winnerId;
    }
}
