namespace MultiplayerGames_Server.Application.UseCases.XOGame.ResponseDTOs;

public record class GameInfoDto
{
    public string Id { get; init; } = string.Empty;
    public string? Player1Id { get; init; }
    public string? Player1 { get; init; }
    public string? Player2Id { get; init; }
    public string? Player2 { get; init; }
    public string Status { get; init; } = string.Empty;
    public string CurrentTurn { get; init; } = string.Empty;
    public string? Winner { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? StartedAt { get; init; }
    public DateTime? EndedAt { get; init; }
    public string[][] Board { get; init; } = Array.Empty<string[]>();
}
