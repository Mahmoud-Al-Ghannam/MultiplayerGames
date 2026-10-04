using MultiplayerGames_Server.Application.Common.Responses;

namespace MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;

/// <summary>
/// Represents the API response returned after a successful authentication operation (e.g., login or sign-up).
/// It wraps the <see cref="AuthData"/> payload within a standard response envelope.
/// </summary>
public record class AuthResponseDto : BaseResponse<AuthData> { }
