using System;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;
using MultiplayerGames_Server.Domain.DomainEvents.XOGame;

namespace MultiplayerGames_Server.Domain.Aggregates.TwoPlayersGame;

public class TwoPlayersGame : AggregateRoot
{
    public string? Player1Id { get; protected set; }
    public string? Player2Id { get; protected set; }
    public GameStatus Status { get; protected set; } = GameStatus.WaitingForPlayers;
    public PlayerNumber? Winner { get; protected set; }
    public DateTime CreatedAtUtc { get; protected set; } = DateTime.UtcNow;
    public DateTime? StartedAtUtc { get; protected set; }
    public DateTime? EndedAtUtc { get; protected set; }

    protected TwoPlayersGame() { }

    protected TwoPlayersGame SetPlayer1(string? playerId)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(playerId))
            playerId = null;

        Player1Id = playerId;
        return this;
    }

    protected TwoPlayersGame SetPlayer2(string? playerId)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(playerId))
            playerId = null;

        Player2Id = playerId;
        return this;
    }

    protected virtual void Start()
    {
        if (Status != GameStatus.WaitingForPlayers)
            return;

        Status = GameStatus.InProgress;
        StartedAtUtc = DateTime.UtcNow;
    }

    public virtual void Join(string playerId)
    {
        if (Status == GameStatus.Finished)
            throw new DomainException(TwoPlayersGameCodes.Error.Finished);

        playerId = playerId?.Trim() ?? string.Empty;

        if (string.Equals(playerId, Player2Id) || string.Equals(playerId, Player1Id))
            return;

        if (string.IsNullOrEmpty(Player1Id))
            Player1Id = playerId;
        else if (string.IsNullOrEmpty(Player2Id))
            Player2Id = playerId;

        if (!string.IsNullOrEmpty(Player1Id) && !string.IsNullOrEmpty(Player2Id))
            Start();
    }

    public virtual void Leave(string playerId)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        if (!string.Equals(playerId, Player1Id) && !string.Equals(playerId, Player2Id))
            throw new DomainException(TwoPlayersGameCodes.Error.NotPlayer);

        if (Status == GameStatus.Finished)
            return;

        if (Status == GameStatus.InProgress)
        {
            if (string.Equals(playerId, Player1Id))
                Winner = PlayerNumber.P2;
            if (string.Equals(playerId, Player2Id))
                Winner = PlayerNumber.P1;
            Status = GameStatus.Finished;
        }
        else
        {
            if (string.Equals(playerId, Player1Id))
                Player1Id = null;
            if (string.Equals(playerId, Player2Id))
                Player2Id = null;
        }
    }
}
