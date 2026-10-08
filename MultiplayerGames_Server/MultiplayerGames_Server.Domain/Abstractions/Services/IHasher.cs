using System;

namespace MultiplayerGames_Server.Domain.Abstractions.Services;

public interface IHasher
{
    public string Hash(string value);
    public bool Verify(string value, string hashedValue);
}
