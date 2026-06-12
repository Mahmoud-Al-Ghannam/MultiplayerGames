namespace MultiplayerGames_Server.Application.UseCases.XOGame.ResponseDTOs;

public record class GameItemDto
{
    public string Id { get; init; } = string.Empty;
    public string? PlayerXId { get; init; }
    public string? PlayerX { get; init; }
    public string? PlayerOId { get; init; }
    public string? PlayerO { get; init; }
    public string Status { get; init; } = string.Empty;
    public string CurrentTurn { get; init; } = string.Empty;
    public string? Winner { get; init; }
}
