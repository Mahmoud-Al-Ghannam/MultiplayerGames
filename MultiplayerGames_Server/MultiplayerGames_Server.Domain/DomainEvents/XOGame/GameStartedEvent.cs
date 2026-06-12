using System;
using MultiplayerGames_Server.Domain.Abstractions;

namespace MultiplayerGames_Server.Domain.DomainEvents.XOGame;

public class GameStartedEvent : DomainEvent
{
    public string GameId { get; }

    public GameStartedEvent(string gameId)
    {
        GameId = gameId;
    }
}
