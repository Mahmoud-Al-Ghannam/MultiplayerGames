using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.Logout;

/// <summary>
/// Represents the command used to log out a user and invalidate their session.
/// </summary>
public record LogoutCommand : IRequest<LogoutResponse>
{
    /// <summary>
    /// Gets the refresh token to be invalidated.
    /// </summary>
    public string RefreshToken { get; init; } = string.Empty;

    /// <summary>
    /// Gets the email of the user logging out.
    /// </summary>
    public string Email { get; init; } = string.Empty;
}
