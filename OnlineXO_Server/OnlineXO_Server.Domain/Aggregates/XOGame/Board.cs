using OnlineXO_Server.Domain.Common;
using OnlineXO_Server.Domain.Common.Codes;
using OnlineXO_Server.Domain.Common.Exceptions;

namespace OnlineXO_Server.Domain.Aggregates.XOGame;

public record Board : ValueObject
{
    public static Board Empty = new Board();
    public Mark?[][] Cells { get; init; }
    public bool IsFull => Cells.SelectMany(cell => cell).All(cell => cell.HasValue);

    public Board()
    {
        Cells = new Mark?[3][];
        for (int i = 0; i < 3; i++)
            Cells[i] = new Mark?[3];
    }

    public string ToJsonString()
    {
        return string.Join(
            ',',
            Cells
                .SelectMany(cell => cell)
                .Select(m => m.HasValue ? ((byte)m.Value).ToString() : string.Empty)
        );
    }

    public static Board FromJsonString(string json)
    {
        var cells = json.Split(',')
            .Select(s => s == string.Empty ? (Mark?)null : (Mark)byte.Parse(s))
            .ToArray();
        Board board = new Board();
        for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            board.Cells[i][j] = cells[i * 3 + j];
        return board;
    }

    public string[][] ToArray()
    {
        string[][] board = new string[3][];
        for (int i = 0; i < 3; i++)
        {
            board[i] = new string[3];
            for (int j = 0; j < 3; j++)
                board[i][j] = Cells[i][j]?.ToString() ?? string.Empty;
        }

        return board;
    }

    public bool IsInside(int row, int col)
    {
        if (row < 0 || row > 3)
            return false;
        if (col < 0 || col > 3)
            return false;
        return true;
    }

    public void EnsureValidPosition(int row, int col)
    {
        if (!IsInside(row, col))
            throw new DomainException(XOGameCodes.Error.Board.InvalidPosition);
    }

    public bool IsEmptyAt(int row, int col)
    {
        EnsureValidPosition(row, col);
        return !Cells[row][col].HasValue;
    }

    public Board SetMark(int row, int col, Mark mark)
    {
        EnsureValidPosition(row, col);

        Board newBoard = this with { Cells = (Mark?[][])Cells.Clone() };
        newBoard.Cells[row][col] = mark;
        return newBoard;
    }

    public bool AllCellsOfColumMatchToMark(int col, Mark mark)
    {
        EnsureValidPosition(0, col);
        for (int i = 0; i < 3; i++)
            if (Cells[i][col] != mark)
                return false;
        return true;
    }

    public bool AllCellsOfAnyColumMatchToMark(Mark mark)
    {
        for (int i = 0; i < 3; i++)
            if (AllCellsOfColumMatchToMark(i, mark))
                return true;
        return false;
    }

    public bool AllCellsOfRowMatchToMark(int row, Mark mark)
    {
        EnsureValidPosition(row, 0);
        for (int i = 0; i < 3; i++)
            if (Cells[row][i] != mark)
                return false;
        return true;
    }

    public bool AllCellsOfAnyRowMatchToMark(Mark mark)
    {
        for (int i = 0; i < 3; i++)
            if (AllCellsOfRowMatchToMark(i, mark))
                return true;
        return false;
    }

    public bool AllCellsOfMainDiagonalMatchToMark(Mark mark)
    {
        for (int i = 0; i < 3; i++)
            if (Cells[i][i] != mark)
                return false;
        return true;
    }

    public bool AllCellsOfSecondaryDiagonalMatchToMark(Mark mark)
    {
        for (int i = 0; i < 3; i++)
            if (Cells[i][3 - 1 - i] != mark)
                return false;
        return true;
    }
}
