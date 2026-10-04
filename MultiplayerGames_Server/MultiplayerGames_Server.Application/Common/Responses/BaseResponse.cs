namespace MultiplayerGames_Server.Application.Common.Responses;

/// <summary>
/// Represents a standard API response envelope that wraps a payload of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the data payload.</typeparam>
public record class BaseResponse<T>
{
    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; init; }

    /// <summary>
    /// Gets an optional message providing additional context about the response.
    /// </summary>
    /// <example>Operation completed successfully.</example>
    public string? Message { get; init; }

    /// <summary>
    /// Gets the data payload of the response.
    /// </summary>
    public T? Data { get; init; }
}
