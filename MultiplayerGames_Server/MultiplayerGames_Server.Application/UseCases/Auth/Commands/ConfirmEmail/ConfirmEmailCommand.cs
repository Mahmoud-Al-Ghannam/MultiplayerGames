using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ConfirmEmail;

/// <summary>
/// Represents the command used to confirm a user's email address using an OTP code.
/// </summary>
/// <param name="Email">The email address of the user to confirm.</param>
/// <param name="OtpCode">The one-time password (OTP) code received via email.</param>
public record ConfirmEmailCommand(string Email, string OtpCode) : IRequest<ConfirmEmailResponse>;
