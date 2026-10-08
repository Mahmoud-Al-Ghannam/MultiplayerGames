using MediatR;
using MultiplayerGames_Server.Application.Abstractions;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.SignUp;

/// <summary>
/// Represents the command used for registering a new user account.
/// </summary>
public record SignUpCommand : IRequest<SignUpResponse>
{
    /// <summary>
    /// Gets the desired email for the new account.
    /// </summary>
    /// <example>newuser123@example.com</example>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Gets the desired username for the new account.
    /// </summary>
    /// <example>newuser123</example>
    public string Username { get; init; } = string.Empty;

    /// <summary>
    /// Gets the password for the new account.
    /// </summary>
    /// <example>SecureP@ssw0rd!</example>
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// Gets the optional profile image for the new account.
    /// </summary>
    public IAppFormFile? ProfileImage { get; init; }
}
