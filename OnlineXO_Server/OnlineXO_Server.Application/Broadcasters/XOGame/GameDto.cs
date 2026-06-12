using XOGameAggregate = OnlineXO_Server.Domain.Aggregates.XOGame.XOGame;

namespace OnlineXO_Server.Application.Broadcasters.XOGame;

public record class GameDto
{
    public string Id { get; init; } = string.Empty;
    public string? PlayerX { get; init; }
    public string? PlayerO { get; init; }
    public string Status { get; init; } = string.Empty;
    public string CurrentTurn { get; init; } = string.Empty;
    public string? Winner { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? StartedAt { get; init; }
    public DateTime? EndedAt { get; init; }
    public string[][] Board { get; init; }

    public GameDto() { }

    public GameDto(XOGameAggregate game, string? playerX, string? playerO)
    {
        Id = game.Id;
        PlayerO = playerO;
        PlayerX = playerX;
        CurrentTurn = game.CurrentTurn.ToString();
        Status = game.Status.ToString();
        Winner = game.Winner.ToString();
        Board = game.Board.ToArray();
        CreatedAt = game.CreatedAtUtc;
        StartedAt = game.StartedAtUtc;
        EndedAt = game.EndedAtUtc;
    }
}
