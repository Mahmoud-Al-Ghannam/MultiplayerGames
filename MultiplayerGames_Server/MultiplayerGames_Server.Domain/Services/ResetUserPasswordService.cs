using System;
using MultiplayerGames_Server.Domain.Abstractions.DomainServices;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;

namespace MultiplayerGames_Server.Domain.Services;

internal class ResetUserPasswordService : IResetUserPasswordService
{
    public void ResetPassword(
        User user,
        Otp otp,
        string newPassword,
        IPasswordHasher passwordHasher
    )
    {
        if (user.Id != otp.UserId)
            throw new DomainException(AuthCodes.Error.OtpIsNotForThatUser);

        if (otp.Purpose != OtpPurpose.Password)
            throw new DomainException(OtpCodes.Error.Purpose.Invalid);

        otp.EnsureVerified();
        user.ResetPassword(newPassword, passwordHasher);
        otp.Use();
    }
}
