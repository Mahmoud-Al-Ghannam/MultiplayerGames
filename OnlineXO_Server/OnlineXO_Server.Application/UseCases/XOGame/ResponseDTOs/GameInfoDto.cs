namespace OnlineXO_Server.Application.UseCases.XOGame.ResponseDTOs;

public record class GameInfoDto
{
    public string Id { get; init; } = string.Empty;
    public string? PlayerXId { get; init; }
    public string? PlayerX { get; init; }
    public string? PlayerOId { get; init; }
    public string? PlayerO { get; init; }
    public string Status { get; init; } = string.Empty;
    public string CurrentTurn { get; init; } = string.Empty;
    public string? Winner { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? StartedAt { get; init; }
    public DateTime? EndedAt { get; init; }
    public string[][] Board { get; init; } = Array.Empty<string[]>();
}
