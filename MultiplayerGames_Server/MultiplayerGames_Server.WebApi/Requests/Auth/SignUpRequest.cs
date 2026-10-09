using System;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.SignUp;
using MultiplayerGames_Server.WebApi.Common;

namespace MultiplayerGames_Server.WebApi.Requests.Auth;

public class SignUpRequest
{
    public string Email { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;

    public IFormFile? ProfileImage { get; init; }

    public SignUpCommand ToCommand()
    {
        return new SignUpCommand
        {
            Email = this.Email,
            Username = this.Username,
            Password = this.Password,
            ProfileImage = this.ProfileImage != null ? new AppFormFile(this.ProfileImage) : null,
        };
    }
}
