using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Infrastructure.Options;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class EmailService : IEmailService
{
    private readonly EmailOptions _emailOptions;

    public EmailService(IOptions<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }

    public async Task SendAsync(
        string toEmail,
        string subject,
        string body,
        bool isHtml,
        int maxAttempts = 3,
        CancellationToken cancellationToken = default
    )
    {
        int attempts = 1;
        while (attempts <= maxAttempts)
        {
            bool success = true;
            try
            {
                await _SendWithoutTryingOnFailureAsync(
                    toEmail,
                    subject,
                    body,
                    isHtml,
                    cancellationToken
                );
            }
            catch
            {
                if (attempts == maxAttempts)
                    throw;
                attempts++;
                success = false;
            }
            if (success)
                break;
        }
    }

    public async Task SendAsync(
        IEnumerable<string> toEmails,
        string subject,
        string body,
        bool isHtml,
        int maxAttempts = 3,
        CancellationToken cancellationToken = default
    )
    {
        foreach (var toEmail in toEmails)
        {
            await SendAsync(toEmail, subject, body, isHtml);
        }
    }

    private async Task _SendWithoutTryingOnFailureAsync(
        string toEmail,
        string subject,
        string body,
        bool isHtml,
        CancellationToken cancellationToken = default
    )
    {
        MimeMessage email = new MimeMessage();
        email.From.Add(new MailboxAddress(_emailOptions.DisplayName, _emailOptions.From));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;
        BodyBuilder bodyBuilder = new BodyBuilder();
        if (isHtml)
            bodyBuilder.HtmlBody = body;
        else
            bodyBuilder.TextBody = body;
        email.Body = bodyBuilder.ToMessageBody();

        using SmtpClient smtp = new SmtpClient();
        await smtp.ConnectAsync(
            _emailOptions.SmtpServer,
            _emailOptions.Port,
            _emailOptions.EnableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.None
        );
        if (!_emailOptions.UseDefaultCredentials)
        {
            await smtp.AuthenticateAsync(_emailOptions.Username, _emailOptions.Password);
        }

        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
