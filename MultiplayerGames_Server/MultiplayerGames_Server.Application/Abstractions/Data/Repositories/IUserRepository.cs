using System;
using MultiplayerGames_Server.Domain.Aggregates.User;

namespace MultiplayerGames_Server.Application.Abstractions.Data.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}
