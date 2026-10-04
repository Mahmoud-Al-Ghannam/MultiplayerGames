namespace MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;

/// <summary>
/// Represents the authentication data returned to the client after a successful login or registration.
/// </summary>
public record class AuthData
{
    /// <summary>
    /// Gets the access token (e.g., JWT) used to authenticate subsequent API requests.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c</example>
    public string AccessToken { get; init; } = string.Empty;
}
