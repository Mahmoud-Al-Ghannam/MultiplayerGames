using System;
using OnlineXO_Server.Application.Abstractions.Data.Repositories;

namespace OnlineXO_Server.Application.Abstractions.Data;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IXOGameRepository XOGames { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<IAppTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}
