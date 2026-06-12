namespace MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;

public record class UserInfoDto
{
    public string Id { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
}
