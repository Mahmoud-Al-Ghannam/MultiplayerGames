using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ForgotPassword
{
    /// <summary>
    /// Represents the command used to request a password reset for a forgotten password.
    /// </summary>
    public record ForgotPasswordCommand : IRequest<ForgotPasswordResponse>
    {
        /// <summary>
        /// Gets the email address of the user who forgot their password.
        /// </summary>
        public string Email { get; init; } = string.Empty;
    }
}
