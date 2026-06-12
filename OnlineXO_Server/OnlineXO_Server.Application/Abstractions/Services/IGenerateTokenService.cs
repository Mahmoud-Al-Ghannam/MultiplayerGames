using System;
using OnlineXO_Server.Domain.Aggregates.User;

namespace OnlineXO_Server.Application.Abstractions.Services;

public interface IGenerateTokenService
{
    public Task<string> GenerateAccessTokenAsync(User user, CancellationToken cancellationToken);
}
