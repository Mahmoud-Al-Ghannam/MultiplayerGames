namespace MultiplayerGames_Server.Application.UseCases.User.RequestDTOs;

/// <summary>
/// Represents the data transfer object used for registering a new user account.
/// </summary>
public record class SignUpDto
{
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
}
