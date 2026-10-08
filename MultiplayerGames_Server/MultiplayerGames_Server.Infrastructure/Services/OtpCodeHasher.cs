using System;
using System.Security.Cryptography;
using System.Text;
using MultiplayerGames_Server.Domain.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

public class OtpCodeHasher : IOtpCodeHasher
{
    public string Hash(string otp)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(otp));
        return Convert.ToBase64String(bytes);
    }

    public bool Verify(string otp, string hashedOtp)
    {
        return Hash(otp) == hashedOtp;
    }
}
