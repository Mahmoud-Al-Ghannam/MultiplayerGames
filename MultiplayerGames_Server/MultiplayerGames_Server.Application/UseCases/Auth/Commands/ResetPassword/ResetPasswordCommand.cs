using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResetPassword
{
    public record ResetPasswordCommand : IRequest<ResetPasswordResponse>
    {
        public string Email { get; init; } = string.Empty;
        public string OtpCode { get; init; } = string.Empty;
        public string NewPassword { get; init; } = string.Empty;
    }
}
