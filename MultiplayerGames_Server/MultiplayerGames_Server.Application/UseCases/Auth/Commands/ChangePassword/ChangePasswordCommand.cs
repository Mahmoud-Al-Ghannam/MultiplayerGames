using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ChangePassword;

public record ChangePasswordCommand : IRequest<ChangePasswordResponse>
{
    public string OldPassword { get; init; } = string.Empty;
    public string NewPassword { get; init; } = string.Empty;
}
