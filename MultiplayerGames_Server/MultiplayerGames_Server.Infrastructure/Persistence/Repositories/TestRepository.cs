using System;
using MultiplayerGames_Server.Application.Abstractions.Data.Repositories;
using MultiplayerGames_Server.Domain.Aggregates.Test;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Repositories;

internal class TestRepository : BaseRepository<Test>, ITestRepository
{
    public TestRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }

    public async Task ReloadAsync(Test entity, CancellationToken cancellationToken)
    {
        await _dbContext.Entry(entity).ReloadAsync(cancellationToken);
    }
}
