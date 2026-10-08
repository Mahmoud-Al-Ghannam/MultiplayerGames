namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.RefreshToken;

public record RefreshTokenData
{
    /// <summary>
    /// Gets the access token (e.g., JWT) used to authenticate subsequent API requests.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c</example>
    public string AccessToken { get; init; } = string.Empty;

    /// <summary>
    /// Gets the refresh token used to obtain a new access token.
    /// </summary>
    /// <example>example-refresh-token-12345</example>
    public string RefreshToken { get; init; } = string.Empty;
}
