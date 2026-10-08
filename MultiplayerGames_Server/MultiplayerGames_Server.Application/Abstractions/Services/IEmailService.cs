using System;

namespace MultiplayerGames_Server.Application.Abstractions.Services;

public interface IEmailService
{
    public Task SendAsync(
        string toEmail,
        string subject,
        string body,
        bool isHtml,
        int maxAttempts = 3,
        CancellationToken cancellationToken = default
    );
    public Task SendAsync(
        IEnumerable<string> toEmails,
        string subject,
        string body,
        bool isHtml,
        int maxAttempts = 3,
        CancellationToken cancellationToken = default
    );
}
