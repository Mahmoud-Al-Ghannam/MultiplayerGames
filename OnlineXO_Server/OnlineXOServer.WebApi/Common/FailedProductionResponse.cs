using OnlineXO_Server.Application.Common.Responses;

namespace OnlineXOServer.WebApi.Common;

public record FailedProductionResponse : BaseResponse<object>
{
    public int StatusCode { get; init; }
}
