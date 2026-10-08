using System;

namespace MultiplayerGames_Server.Domain.Abstractions.Services;

public interface IIdGenerator
{
    string NewId();
}
