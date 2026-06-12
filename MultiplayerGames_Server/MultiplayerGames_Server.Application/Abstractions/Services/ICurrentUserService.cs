using System;

namespace MultiplayerGames_Server.Application.Abstractions.Services;

public interface ICurrentUserService
{
    string? GetUsername();
    string? GetUserId();
    bool IsAuthenticated();
}
