using System;
using MultiplayerGames_Server.Domain.Abstractions;

namespace MultiplayerGames_Server.Domain.DomainEvents.XOGame;

public class XOGameCreatedEvent : DomainEvent
{
    public string GameId { get; }
    public string? Player1Id { get; }
    public string? Player2Id { get; }

    public XOGameCreatedEvent(string gameId, string? player1Id, string? player2Id)
    {
        GameId = gameId;
        Player1Id = player1Id;
        Player2Id = player2Id;
    }
}
