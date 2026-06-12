using OnlineXO_Server.Application.Common.Responses;

namespace OnlineXOServer.WebApi.Common;

public record FailedDevelopmentResponse : BaseResponse<object>
{
    public int StatusCode { get; init; }
    public string? StackTrace { get; init; }
}
