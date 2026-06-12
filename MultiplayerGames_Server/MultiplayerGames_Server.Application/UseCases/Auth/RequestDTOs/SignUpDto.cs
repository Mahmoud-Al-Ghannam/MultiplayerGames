namespace MultiplayerGames_Server.Application.UseCases.User.RequestDTOs;

public record class SignUpDto
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
