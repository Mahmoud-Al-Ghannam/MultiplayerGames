using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResetPassword
{
    /// <summary>
    /// Represents the command used to reset a user's password using a verification token.
    /// </summary>
    public record ResetPasswordCommand : IRequest<ResetPasswordResponse>
    {
        /// <summary>
        /// Gets the email address of the user resetting their password.
        /// </summary>
        public string Email { get; init; } = string.Empty;

        /// <summary>
        /// Gets the OTP code used to verify the reset request.
        /// </summary>
        public string OtpCode { get; init; } = string.Empty;

        /// <summary>
        /// Gets the new password to be set.
        /// </summary>
        public string NewPassword { get; init; } = string.Empty;
    }
}
