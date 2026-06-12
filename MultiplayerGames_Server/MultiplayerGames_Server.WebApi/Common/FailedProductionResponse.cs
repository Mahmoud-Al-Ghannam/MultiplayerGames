using MultiplayerGames_Server.Application.Common.Responses;

namespace MultiplayerGames_Server.WebApi.Common;

public record FailedProductionResponse : BaseResponse<object>
{
    public int StatusCode { get; init; }
}
