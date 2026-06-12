using System;
using MultiplayerGames_Server.Domain.Aggregates.User;

namespace MultiplayerGames_Server.Application.Abstractions.Services;

public interface IGenerateTokenService
{
    public Task<string> GenerateAccessTokenAsync(User user, CancellationToken cancellationToken);
}
