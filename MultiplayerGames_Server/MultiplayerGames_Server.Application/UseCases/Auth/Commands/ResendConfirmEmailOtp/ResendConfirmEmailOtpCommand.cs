using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResendConfirmEmailOtp;

/// <summary>
/// Represents the command used to resend the email confirmation OTP code to the user.
/// </summary>
public record ResendConfirmEmailOtpCommand : IRequest<ResendConfirmEmailOtpResponse>
{
    /// <summary>
    /// Gets the email address to which the OTP should be resent.
    /// </summary>
    public string Email { get; init; } = string.Empty;
}
