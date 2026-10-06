using System;
using MultiplayerGames_Server.Application.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class EmailTemplateService : IEmailTemplateService
{
    public string GenerateWelcomeTemplate(string userName)
    {
        return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .welcome {{ background-color: #d4edda; border: 1px solid #c3e6cb; padding: 15px; border-radius: 4px; }}
        .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #eee; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='welcome'>
        <h2>Welcome to Our Application! 🎉</h2>
        </div>
        <p>Hello <strong>{{userName}}</strong>,</p>
        <p>Thank you for confirming your email address. Your account is now active and ready to use.</p>
        <p>We're excited to have you on board! Here's what you can do next:</p>
        <ul>
            <li>Complete your profile</li>
            <li>Explore our features</li>
            <li>Get started with your first project</li>
        </ul>
        <p>If you have any questions, feel free to contact our support team.</p>
        <div class='footer'>
            <p>Best regards,<br>The Application Team</p>
        </div>
    </div>
</body>
</html>";
    }

    public string GenerateEmailConfirmationTemplate(
        string otpCode,
        string userName,
        int expirationMinutes
    )
    {
        return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .otp-code {{ background-color: #f8f9fa; border: 2px solid #007bff; padding: 20px; text-align: center; border-radius: 8px; margin: 20px 0; font-size: 32px; font-weight: bold; letter-spacing: 5px; color: #007bff; }}
        .warning {{ background-color: #fff3cd; border: 1px solid #ffeaa7; padding: 12px; border-radius: 4px; margin: 15px 0; }}
        .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #eee; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='container'>
        <h2>Email Verification Code</h2>
        <p>Hello {userName},</p>
        <p>Thank you for registering! Please use the verification code below to confirm your email address:</p>
        <div class='otp-code'>{otpCode}</div>
        <div class='warning'>
            <strong>Important:</strong> This code will expire in {expirationMinutes} minutes. Please do not share this code with anyone.
        </div>
        <p>If you didn't create an account, please ignore this email.</p>
        <div class='footer'>
            <p>This is an automated message, please do not reply to this email.</p>
        </div>
    </div>
</body>
</html>";
    }

    public string GenerateResetPasswordTemplate(
        string otpCode,
        string userName,
        int expirationMinutes
    )
    {
        return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .otp-code {{ background-color: #f8f9fa; border: 2px solid #dc3545; padding: 20px; text-align: center; border-radius: 8px; margin: 20px 0; font-size: 32px; font-weight: bold; letter-spacing: 5px; color: #dc3545; }}
        .warning {{ background-color: #fff3cd; border: 1px solid #ffeaa7; padding: 12px; border-radius: 4px; margin: 15px 0; }}
        .security {{ background-color: #f8d7da; border: 1px solid #f5c6cb; padding: 12px; border-radius: 4px; margin: 15px 0; }}
        .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #eee; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='container'>
        <h2>Password Reset Code</h2>
        <p>Hello {userName},</p>
        <p>We received a request to reset your password. Please use the verification code below to reset your password:</p>
        <div class='otp-code'>{otpCode}</div>
        <div class='warning'>
            <strong>Important:</strong> This code will expire in {expirationMinutes} minutes. Please do not share this code with anyone.
        </div>
        <div class='security'>
            <strong>Security Notice:</strong> If you didn't request a password reset, please ignore this email and consider changing your password immediately.
        </div>
        <p>Enter this code in the password reset page to create a new password.</p>
        <div class='footer'>
            <p>This is an automated message, please do not reply to this email.</p>
        </div>
    </div>
</body>
</html>";
    }
}
