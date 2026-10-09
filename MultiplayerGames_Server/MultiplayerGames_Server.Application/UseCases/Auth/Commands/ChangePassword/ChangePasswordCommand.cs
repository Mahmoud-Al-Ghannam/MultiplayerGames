using MediatR;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ChangePassword;

/// <summary>
/// Represents the command used to change the password for an authenticated user.
/// </summary>
public record ChangePasswordCommand : IRequest<ChangePasswordResponse>
{
    /// <summary>
    /// Gets the current password of the user.
    /// </summary>
    public string OldPassword { get; init; } = string.Empty;

    /// <summary>
    /// Gets the new password the user wishes to set.
    /// </summary>
    public string NewPassword { get; init; } = string.Empty;
}
