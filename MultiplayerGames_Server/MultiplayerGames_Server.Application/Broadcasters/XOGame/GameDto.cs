using XOGameAggregate = MultiplayerGames_Server.Domain.Aggregates.XOGame.XOGame;

namespace MultiplayerGames_Server.Application.Broadcasters.XOGame;

public record class GameDto
{
    public string Id { get; init; } = string.Empty;
    public string? Player1 { get; init; }
    public string? Player2 { get; init; }
    public string Status { get; init; } = string.Empty;
    public string CurrentTurn { get; init; } = string.Empty;
    public string? Winner { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? StartedAt { get; init; }
    public DateTime? EndedAt { get; init; }
    public string[][] Board { get; init; }

    public GameDto() { }

    public GameDto(XOGameAggregate game, string? player1, string? player2)
    {
        Id = game.Id;
        Player2 = player2;
        Player1 = player1;
        CurrentTurn = game.CurrentTurn.ToString();
        Status = game.Status.ToString();
        Winner = game.Winner.ToString();
        Board = game.Board.ToArray();
        CreatedAt = game.CreatedAtUtc;
        StartedAt = game.StartedAtUtc;
        EndedAt = game.EndedAtUtc;
    }
}
