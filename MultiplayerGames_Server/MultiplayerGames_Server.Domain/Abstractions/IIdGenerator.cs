using System;

namespace MultiplayerGames_Server.Domain.Abstractions;

public interface IIdGenerator
{
    string NewId();
}
