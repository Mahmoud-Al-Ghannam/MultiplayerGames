using System;
using System.Security.Cryptography;
using System.Text;
using MultiplayerGames_Server.Domain.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

public class RefreshTokenHasher : IRefreshTokenHasher
{
    public string Hash(string token)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
        return Convert.ToBase64String(bytes);
    }

    public bool Verify(string token, string hashedToken)
    {
        return Hash(token) == hashedToken;
    }
}
