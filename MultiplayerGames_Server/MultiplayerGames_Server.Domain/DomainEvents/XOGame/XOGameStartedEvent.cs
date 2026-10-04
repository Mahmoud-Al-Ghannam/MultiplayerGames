using System;
using MultiplayerGames_Server.Domain.Abstractions;

namespace MultiplayerGames_Server.Domain.DomainEvents.XOGame;

public class XOGameStartedEvent : DomainEvent
{
    public string GameId { get; }

    public XOGameStartedEvent(string gameId)
    {
        GameId = gameId;
    }
}
