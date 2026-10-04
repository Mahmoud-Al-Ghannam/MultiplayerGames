using System;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Aggregates.TwoPlayersGame;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;

namespace MultiplayerGames_Server.Domain.DomainEvents.XOGame;

public class XOGameEndedEvent : DomainEvent
{
    public string GameId { get; }
    public PlayerNumber? Winner { get; }
    public string? WinnerId { get; }

    public XOGameEndedEvent(string gameId, PlayerNumber? winner, string? winnerId)
    {
        GameId = gameId;
        Winner = winner;
        WinnerId = winnerId;
    }
}
