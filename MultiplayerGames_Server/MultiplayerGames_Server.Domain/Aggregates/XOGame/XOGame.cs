using System;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.TwoPlayersGame;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;
using MultiplayerGames_Server.Domain.DomainEvents.XOGame;
using TwoPlayersGameAgg = MultiplayerGames_Server.Domain.Aggregates.TwoPlayersGame.TwoPlayersGame;

namespace MultiplayerGames_Server.Domain.Aggregates.XOGame;

public class XOGame : TwoPlayersGameAgg
{
    public Board Board { get; private set; } = Board.Empty;
    public Mark FirstPlayerMark { get; private set; } =
        new Random().Next(0, 1) == 0 ? Mark.O : Mark.X;
    public Mark SecondPlayerMark => FirstPlayerMark == Mark.O ? Mark.X : Mark.O;
    public PlayerNumber CurrentTurn { get; private set; } =
        new Random().Next(0, 1) == 0 ? PlayerNumber.P1 : PlayerNumber.P2;

    public DateTime? TurnStartedAtUtc { get; private set; }

    private XOGame() { }

    public static XOGame Create(string firstPlayerId, IIdGenerator idGenerator)
    {
        var game = new XOGame() { Id = idGenerator.NewId() };
        game.SetPlayer1(firstPlayerId);
        game.AddDomainEvent(new XOGameCreatedEvent(game.Id, game.Player1Id, game.Player2Id));

        return game;
    }

    public XOGame SwitchTurn()
    {
        CurrentTurn = CurrentTurn == PlayerNumber.P1 ? PlayerNumber.P2 : PlayerNumber.P1;
        TurnStartedAtUtc = DateTime.UtcNow;
        return this;
    }

    protected override void Start()
    {
        base.Start();
        TurnStartedAtUtc = DateTime.UtcNow;
        AddDomainEvent(new XOGameStartedEvent(Id));
    }

    public override void Join(string playerId)
    {
        base.Join(playerId);
        AddDomainEvent(new XOGameUpdatedEvent(Id));
    }

    public override void Leave(string playerId)
    {
        base.Leave(playerId);
        AddDomainEvent(new XOGameUpdatedEvent(Id));
    }

    public void EnsureCanMove(string playerId, int row, int col)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        if (
            string.Equals(Player1Id, playerId) == false
            && string.Equals(Player1Id, playerId) == false
        )
            throw new DomainException(XOGameCodes.Error.NotPlayer);

        if (Status != GameStatus.InProgress)
            throw new DomainException(XOGameCodes.Error.NotInProgress);

        PlayerNumber playerNumber = GetPlayerNumber(playerId);
        if (CurrentTurn != playerNumber)
            throw new DomainException(XOGameCodes.Error.NotPlayerTurn);

        if (!Board.IsEmptyAt(row, col))
            throw new DomainException(XOGameCodes.Error.Board.CellAlreadyOccupied);
    }

    public void MakeMove(string playerId, int row, int col)
    {
        playerId = playerId?.Trim() ?? string.Empty;
        EnsureCanMove(playerId, row, col);

        // Apply move
        Mark currentMark = GetMarkForPlayer(playerId);
        Board = Board.SetMark(row, col, currentMark);

        // Check win / draw
        if (HasWinner(out var winner))
        {
            Status = GameStatus.Finished;
            Winner = winner;
            EndedAtUtc = DateTime.UtcNow;
            AddDomainEvent(
                new XOGameEndedEvent(
                    Id,
                    Winner!.Value,
                    winner == PlayerNumber.P1 ? Player1Id : Player2Id
                )
            );
        }
        else if (Board.IsFull)
        {
            Status = GameStatus.Finished;
            Winner = null; // draw
            EndedAtUtc = DateTime.UtcNow;
            AddDomainEvent(new XOGameEndedEvent(Id, null, null));
        }
        else
        {
            // Switch turn
            SwitchTurn();
            AddDomainEvent(new XOGameMoveMadeEvent(Id, playerId, row, col, currentMark));
        }
    }

    public bool HasWinner(out PlayerNumber? winner)
    {
        winner = null;

        if (
            Board.AllCellsOfAnyRowMatchToMark(Mark.X)
            || Board.AllCellsOfAnyColumMatchToMark(Mark.X)
            || Board.AllCellsOfMainDiagonalMatchToMark(Mark.X)
            || Board.AllCellsOfSecondaryDiagonalMatchToMark(Mark.X)
        )
        {
            winner = FirstPlayerMark == Mark.X ? PlayerNumber.P1 : PlayerNumber.P2;
            return true;
        }

        if (
            Board.AllCellsOfAnyRowMatchToMark(Mark.O)
            || Board.AllCellsOfAnyColumMatchToMark(Mark.O)
            || Board.AllCellsOfMainDiagonalMatchToMark(Mark.O)
            || Board.AllCellsOfSecondaryDiagonalMatchToMark(Mark.O)
        )
        {
            winner = FirstPlayerMark == Mark.O ? PlayerNumber.P1 : PlayerNumber.P2;
            return true;
        }

        return false;
    }

    private Mark GetMarkForPlayer(string playerId)
    {
        if (playerId == Player1Id)
            return FirstPlayerMark;
        if (playerId == Player2Id)
            return SecondPlayerMark;
        throw new DomainException(XOGameCodes.Error.NotPlayer);
    }

    private PlayerNumber GetPlayerNumber(string playerId)
    {
        if (playerId == Player1Id)
            return PlayerNumber.P1;
        if (playerId == Player2Id)
            return PlayerNumber.P2;
        throw new DomainException(XOGameCodes.Error.NotPlayer);
    }
}
