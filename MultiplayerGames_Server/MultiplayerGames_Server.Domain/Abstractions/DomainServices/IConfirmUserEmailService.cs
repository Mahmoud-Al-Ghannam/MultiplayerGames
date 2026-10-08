using System;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Aggregates.User;

namespace MultiplayerGames_Server.Domain.Abstractions.DomainServices;

public interface IConfirmUserEmailService
{
    public void ConfirmEmail(User user, Otp otp);
}
