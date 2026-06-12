using System;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;
using MultiplayerGames_Server.Domain.DomainEvents.XOGame;

namespace MultiplayerGames_Server.Domain.Aggregates.XOGame;

public class XOGame : AggregateRoot
{
    public string? PlayerXId { get; private set; }
    public string? PlayerOId { get; private set; }

    public GameStatus Status { get; private set; } = GameStatus.WaitingForPlayers;
    public Board Board { get; private set; } = Board.Empty;
    public Mark CurrentTurn { get; private set; } = new Random().Next(0, 1) == 0 ? Mark.X : Mark.O;
    public Mark? Winner { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? StartedAtUtc { get; private set; }
    public DateTime? EndedAtUtc { get; private set; }

    private XOGame() { }

    public static XOGame Create(string firstPlayerId, IIdGenerator idGenerator)
    {
        var game = new XOGame() { Id = idGenerator.NewId() };

        game.SetPlayerX(firstPlayerId);
        game.AddDomainEvent(new GameCreatedEvent(game.Id, game.PlayerXId, game.PlayerOId));

        return game;
    }

    private XOGame SetPlayerX(string? playerXId)
    {
        playerXId = playerXId?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(playerXId))
            playerXId = null;

        PlayerXId = playerXId;
        return this;
    }

    private XOGame SetPlayerO(string? playerOId)
    {
        playerOId = playerOId?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(playerOId))
            playerOId = null;

        PlayerOId = playerOId;
        return this;
    }

    public XOGame SwitchTurn()
    {
        CurrentTurn = CurrentTurn == Mark.X ? Mark.O : Mark.X;
        return this;
    }

    private void Start()
    {
        if (Status != GameStatus.WaitingForPlayers)
            return;

        Status = GameStatus.InProgress;
        StartedAtUtc = DateTime.UtcNow;
        AddDomainEvent(new GameStartedEvent(Id));
    }

    public XOGame Join(string playerId)
    {
        if (Status == GameStatus.Finished)
            throw new DomainException(XOGameCodes.Error.Finished);

        playerId = playerId?.Trim() ?? string.Empty;

        if (string.Equals(playerId, PlayerOId) || string.Equals(playerId, PlayerXId))
            return this;

        if (string.IsNullOrEmpty(PlayerXId))
            PlayerXId = playerId;
        else if (string.IsNullOrEmpty(PlayerOId))
            PlayerOId = playerId;

        if (!string.IsNullOrEmpty(PlayerOId) && !string.IsNullOrEmpty(PlayerXId))
            Start();
        AddDomainEvent(new GameUpdatedEvent(Id));
        return this;
    }

    public XOGame Leave(string playerId)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        if (!string.Equals(playerId, PlayerOId) && !string.Equals(playerId, PlayerXId))
            throw new DomainException(XOGameCodes.Error.NotPlayer);

        if (Status == GameStatus.Finished)
            return this;

        if (Status == GameStatus.InProgress)
        {
            if (string.Equals(playerId, PlayerXId))
                Winner = Mark.O;
            if (string.Equals(playerId, PlayerOId))
                Winner = Mark.X;
            Status = GameStatus.Finished;
        }
        else
        {
            if (string.Equals(playerId, PlayerXId))
                PlayerXId = null;
            if (string.Equals(playerId, PlayerOId))
                PlayerOId = null;
        }

        AddDomainEvent(new GameUpdatedEvent(Id));
        return this;
    }

    public void EnsureCanMove(string playerId, int row, int col)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        if (
            string.Equals(PlayerXId, playerId) == false
            && string.Equals(PlayerOId, playerId) == false
        )
            throw new DomainException(XOGameCodes.Error.NotPlayer);

        if (Status != GameStatus.InProgress)
            throw new DomainException(XOGameCodes.Error.NotInProgress);

        Mark expectedMark = GetMarkForPlayer(playerId);
        if (CurrentTurn != expectedMark)
            throw new DomainException(XOGameCodes.Error.NotPlayerTurn);

        if (!Board.IsEmptyAt(row, col))
            throw new InvalidOperationException(XOGameCodes.Error.Board.CellAlreadyOccupied);
    }

    public void MakeMove(string playerId, int row, int col)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        EnsureCanMove(playerId, row, col);
        // Apply move
        Board = Board.SetMark(row, col, CurrentTurn);

        // Check win / draw
        if (HasWinner(out var winner))
        {
            Status = GameStatus.Finished;
            Winner = winner;
            EndedAtUtc = DateTime.UtcNow;
            AddDomainEvent(
                new GameEndedEvent(Id, Winner!.Value, winner == Mark.X ? PlayerXId : PlayerOId)
            );
        }
        else if (Board.IsFull)
        {
            Status = GameStatus.Finished;
            Winner = null; // draw
            EndedAtUtc = DateTime.UtcNow;
            AddDomainEvent(new GameEndedEvent(Id, null, null));
        }
        else
        {
            // Switch turn
            SwitchTurn();
            AddDomainEvent(new MoveMadeEvent(Id, playerId, row, col, CurrentTurn));
        }
    }

    public bool HasWinner(out Mark? winner)
    {
        winner = null;

        if (
            Board.AllCellsOfAnyRowMatchToMark(Mark.X)
            || Board.AllCellsOfAnyColumMatchToMark(Mark.X)
            || Board.AllCellsOfMainDiagonalMatchToMark(Mark.X)
            || Board.AllCellsOfSecondaryDiagonalMatchToMark(Mark.X)
        )
        {
            winner = Mark.X;
            return true;
        }

        if (
            Board.AllCellsOfAnyRowMatchToMark(Mark.O)
            || Board.AllCellsOfAnyColumMatchToMark(Mark.O)
            || Board.AllCellsOfMainDiagonalMatchToMark(Mark.O)
            || Board.AllCellsOfSecondaryDiagonalMatchToMark(Mark.O)
        )
        {
            winner = Mark.O;
            return true;
        }

        return false;
    }

    private Mark GetMarkForPlayer(string playerId)
    {
        if (playerId == PlayerXId)
            return Mark.X;
        if (playerId == PlayerOId)
            return Mark.O;
        throw new DomainException(XOGameCodes.Error.NotPlayer);
    }
}
