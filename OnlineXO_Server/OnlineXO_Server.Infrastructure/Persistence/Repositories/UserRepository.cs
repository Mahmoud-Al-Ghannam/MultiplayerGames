using System;
using Microsoft.EntityFrameworkCore;
using OnlineXO_Server.Application.Abstractions.Data.Repositories;
using OnlineXO_Server.Domain.Aggregates.User;
using OnlineXO_Server.Infrastructure.Persistence.Data;

namespace OnlineXO_Server.Infrastructure.Persistence.Repositories;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }

    public async Task<User?> GetByUsernameAsync(
        string username,
        CancellationToken cancellationToken
    )
    {
        username = username?.Trim() ?? string.Empty;
        return await _dbSet.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }
}
