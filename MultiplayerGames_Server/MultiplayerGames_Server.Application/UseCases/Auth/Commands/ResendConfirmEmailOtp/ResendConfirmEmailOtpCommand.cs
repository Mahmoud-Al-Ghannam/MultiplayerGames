using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResendConfirmEmailOtp;

public record ResendConfirmEmailOtpCommand : IRequest<ResendConfirmEmailOtpResponse>
{
    public string Email { get; init; } = string.Empty;
}
