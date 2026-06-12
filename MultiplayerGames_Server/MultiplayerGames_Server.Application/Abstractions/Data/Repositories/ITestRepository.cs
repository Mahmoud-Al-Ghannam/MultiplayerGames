using System;
using MultiplayerGames_Server.Domain.Aggregates.Test;

namespace MultiplayerGames_Server.Application.Abstractions.Data.Repositories;

public interface ITestRepository : IBaseRepository<Test>
{
    public Task ReloadAsync(Test entity, CancellationToken cancellationToken);
}
