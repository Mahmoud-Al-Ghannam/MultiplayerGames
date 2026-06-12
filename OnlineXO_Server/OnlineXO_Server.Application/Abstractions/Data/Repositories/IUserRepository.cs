using System;
using OnlineXO_Server.Domain.Aggregates.User;

namespace OnlineXO_Server.Application.Abstractions.Data.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}
