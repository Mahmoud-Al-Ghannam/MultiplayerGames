namespace MultiplayerGames_Server.Application.UseCases.User.RequestDTOs;

/// <summary>
/// Represents the data transfer object used for user login authentication.
/// </summary>
public record class LoginDto
{
    /// <summary>
    /// Gets the username of the user attempting to log in.
    /// </summary>
    /// <example>johndoe</example>
    public string Username { get; init; } = string.Empty;

    /// <summary>
    /// Gets the password of the user attempting to log in.
    /// </summary>
    /// <example>P@ssw0rd123</example>
    public string Password { get; init; } = string.Empty;
}
