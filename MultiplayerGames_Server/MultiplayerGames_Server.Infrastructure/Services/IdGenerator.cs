using System;
using MultiplayerGames_Server.Domain.Abstractions;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class IdGenerator : IIdGenerator
{
    public string NewId()
    {
        return Ulid.NewUlid().ToString().ToLowerInvariant();
    }
}
