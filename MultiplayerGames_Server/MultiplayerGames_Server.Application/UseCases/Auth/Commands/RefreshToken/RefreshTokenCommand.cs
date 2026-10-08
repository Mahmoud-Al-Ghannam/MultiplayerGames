using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.RefreshToken;

public record RefreshTokenCommand : IRequest<RefreshTokenResponse>
{
    public string RefreshToken { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
