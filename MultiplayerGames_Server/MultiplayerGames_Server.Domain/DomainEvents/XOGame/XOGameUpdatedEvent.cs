using System;

namespace MultiplayerGames_Server.Domain.DomainEvents.XOGame;

public class XOGameUpdatedEvent : DomainEvent
{
    public string GameId { get; } = string.Empty;

    public XOGameUpdatedEvent(string gameId)
    {
        GameId = gameId;
    }
}
