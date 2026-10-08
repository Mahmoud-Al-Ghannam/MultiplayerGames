using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MultiplayerGames_Server.Domain.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class PasswordHasher : IPasswordHasher
{
    public string Hash(string value)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
        return Convert.ToBase64String(hashedBytes);
    }

    public bool Verify(string value, string hashedValue)
    {
        var hashOfInput = Hash(value);
        return hashOfInput == hashedValue;
    }
}
