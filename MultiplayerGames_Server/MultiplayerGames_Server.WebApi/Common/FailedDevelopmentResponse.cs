using MultiplayerGames_Server.Application.Common.Responses;

namespace MultiplayerGames_Server.WebApi.Common;

public record FailedDevelopmentResponse : BaseResponse<object>
{
    public int StatusCode { get; init; }
    public string? StackTrace { get; init; }
}
