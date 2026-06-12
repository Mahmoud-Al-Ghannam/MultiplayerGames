using System;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineXO_Server.Application.Abstractions.Data;
using OnlineXO_Server.Application.Abstractions.Data.Repositories;
using OnlineXO_Server.Infrastructure.Persistence.Repositories;

namespace OnlineXO_Server.Infrastructure.Persistence.Data;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Users = new UserRepository(dbContext);
        XOGames = new XOGameRepository(dbContext);
    }

    public IUserRepository Users { get; }

    public IXOGameRepository XOGames { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private sealed class AppTransaction : IAppTransaction
    {
        private readonly IDbContextTransaction _inner;

        public AppTransaction(IDbContextTransaction inner)
        {
            _inner = inner;
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _inner.CommitAsync(cancellationToken);
        }

        public Task RollbackAsync(CancellationToken cancellationToken)
        {
            return _inner.RollbackAsync(cancellationToken);
        }

        public ValueTask DisposeAsync()
        {
            return _inner.DisposeAsync();
        }
    }

    public async Task<IAppTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        var efTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        return new AppTransaction(efTransaction);
    }
}
