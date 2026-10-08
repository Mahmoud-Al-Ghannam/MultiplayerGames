using System;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Aggregates.User;

namespace MultiplayerGames_Server.Domain.Abstractions.DomainServices;

public interface IResetUserPasswordService
{
    public void ResetPassword(
        User user,
        Otp otp,
        string newPassword,
        IPasswordHasher passwordHasher
    );
}
