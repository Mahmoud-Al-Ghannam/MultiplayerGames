using System;
using MultiplayerGames_Server.Domain.Abstractions.DomainServices;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;

namespace MultiplayerGames_Server.Domain.Services;

internal class ConfirmUserEmailService : IConfirmUserEmailService
{
    public void ConfirmEmail(User user, Otp otp)
    {
        if (user.Id != otp.UserId)
            throw new DomainException(AuthCodes.Error.OtpIsNotForThatUser);

        if (otp.Purpose != OtpPurpose.Email)
            throw new DomainException(OtpCodes.Error.Purpose.Invalid);

        otp.EnsureVerified();
        user.ConfirmEmail();
        otp.Use();
    }
}
