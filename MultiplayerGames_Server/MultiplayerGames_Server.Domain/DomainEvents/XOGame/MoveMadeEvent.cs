using System;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;

namespace MultiplayerGames_Server.Domain.DomainEvents.XOGame;

public class MoveMadeEvent : DomainEvent
{
    public string GameId { get; }
    public string PlayerId { get; }
    public int Row { get; }
    public int Col { get; }
    public Mark Mark { get; }

    public MoveMadeEvent(string gameId, string playerId, int row, int col, Mark mark)
    {
        GameId = gameId;
        PlayerId = playerId;
        Row = row;
        Col = col;
        Mark = mark;
    }
}
