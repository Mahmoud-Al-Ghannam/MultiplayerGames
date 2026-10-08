using System;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Abstractions.Services;

namespace MultiplayerGames_Server.Infrastructure.Services;

internal class IdGenerator : IIdGenerator
{
    public string NewId()
    {
        return Ulid.NewUlid().ToString().ToLowerInvariant();
    }
}
