using System;
using System.Security.Cryptography;
using System.Text;
using MultiplayerGames_Server.Domain.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

public class OtpService : IOtpService
{
    private readonly Random _random = new();

    public string GenerateOtpCode(int codeLength)
    {
        var min = (int)Math.Pow(10, codeLength - 1);
        var max = (int)Math.Pow(10, codeLength) - 1;
        return _random.Next(min, max).ToString();
    }
}
