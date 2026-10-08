using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ForgotPassword
{
    public record ForgotPasswordCommand : IRequest<ForgotPasswordResponse>
    {
        public string Email { get; init; } = string.Empty;
    }
}
