namespace MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;

/// <summary>
/// Represents a data transfer object containing basic public information about a user.
/// </summary>
public record class UserInfoDto
{
    /// <summary>
    /// Gets the unique identifier of the user.
    /// </summary>
    /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
    public string Id { get; init; } = string.Empty;

    /// <summary>
    /// Gets the username of the user.
    /// </summary>
    /// <example>johndoe</example>
    public string Username { get; init; } = string.Empty;
}
