namespace MultiplayerGames_Server.Application.UseCases.XOGame.ResponseDTOs;

public record class GameItemDto
{
    public string Id { get; init; } = string.Empty;
    public string? Player1Id { get; init; }
    public string? Player1 { get; init; }
    public string? Player2Id { get; init; }
    public string? Player2 { get; init; }
    public string Status { get; init; } = string.Empty;
    public string CurrentTurn { get; init; } = string.Empty;
    public string? Winner { get; init; }
}
