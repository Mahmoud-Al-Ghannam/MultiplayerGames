using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ConfirmEmail;

public record ConfirmEmailCommand(string Email, string OtpCode) : IRequest<ConfirmEmailResponse>;
