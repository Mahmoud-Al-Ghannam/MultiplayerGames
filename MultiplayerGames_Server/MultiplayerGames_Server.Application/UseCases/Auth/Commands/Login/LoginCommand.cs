using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.Login;

/// <summary>
/// Represents the command used for user login authentication.
/// </summary>
public record LoginCommand : IRequest<LoginResponse>
{
    /// <summary>
    /// Gets the email of the user attempting to log in.
    /// </summary>
    /// <example>johndoe@example.com</example>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Gets the password of the user attempting to log in.
    /// </summary>
    /// <example>P@ssw0rd123</example>
    public string Password { get; init; } = string.Empty;
}
