using System;

namespace MultiplayerGames_Server.Infrastructure.Options;

public class EmailOptions
{
    public string From { get; set; } = string.Empty;
    public string SmtpServer { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool EnableSsl { get; set; } = true;
    public string DisplayName { get; set; } = string.Empty;
    public bool UseDefaultCredentials { get; set; } = false;
}
