using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.Logout;

public record LogoutCommand : IRequest<LogoutResponse>
{
    public string RefreshToken { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
