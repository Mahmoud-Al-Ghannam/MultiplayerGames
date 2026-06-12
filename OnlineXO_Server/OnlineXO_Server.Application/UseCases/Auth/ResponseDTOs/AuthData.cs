namespace OnlineXO_Server.Application.UseCases.User.ResponseDTOs;

public record class AuthData
{
    public string AccessToken { get; init; } = string.Empty;
}
