using System;
using OnlineXO_Server.Domain.Abstractions;

namespace OnlineXO_Server.Infrastructure.Services;

internal class IdGenerator : IIdGenerator
{
    public string NewId()
    {
        return Ulid.NewUlid().ToString().ToLowerInvariant();
    }
}
