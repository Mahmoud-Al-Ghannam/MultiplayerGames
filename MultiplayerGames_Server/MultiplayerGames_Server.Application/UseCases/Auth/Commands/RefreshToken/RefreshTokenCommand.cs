using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.RefreshToken;

/// <summary>
/// Represents the command used to refresh an expired access token using a refresh token.
/// </summary>
public record RefreshTokenCommand : IRequest<RefreshTokenResponse>
{
    /// <summary>
    /// Gets the refresh token used to generate a new access token.
    /// </summary>
    public string RefreshToken { get; init; } = string.Empty;

    /// <summary>
    /// Gets the email of the user requesting the token refresh.
    /// </summary>
    public string Email { get; init; } = string.Empty;
}
