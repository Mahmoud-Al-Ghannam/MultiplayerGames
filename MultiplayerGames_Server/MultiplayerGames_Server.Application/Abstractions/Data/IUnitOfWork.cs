using System;
using MultiplayerGames_Server.Application.Abstractions.Data.Repositories;

namespace MultiplayerGames_Server.Application.Abstractions.Data;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IXOGameRepository XOGames { get; }
    ITestRepository Tests { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<IAppTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}
