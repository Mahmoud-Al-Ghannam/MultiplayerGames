using System;

namespace MultiplayerGames_Server.Application.Abstractions.Services;

public interface IEmailTemplateService
{
    string GenerateWelcomeTemplate(string userName);
    string GenerateEmailConfirmationTemplate(
        string otpCode,
        string userName,
        int expirationMinutes
    );
    string GenerateResetPasswordTemplate(string otpCode, string userName, int expirationMinutes);
}
