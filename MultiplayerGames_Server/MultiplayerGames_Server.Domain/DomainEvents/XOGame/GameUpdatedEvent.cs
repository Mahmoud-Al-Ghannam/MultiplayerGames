using System;

namespace MultiplayerGames_Server.Domain.DomainEvents.XOGame;

public class GameUpdatedEvent : DomainEvent
{
    public string GameId { get; } = string.Empty;

    public GameUpdatedEvent(string gameId)
    {
        GameId = gameId;
    }
}
