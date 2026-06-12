using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Application.Abstractions.Data.Repositories;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Repositories;

internal class BaseRepository<T> : IBaseRepository<T>
    where T : AggregateRoot
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        // SaveChanges will be handled by UnitOfWork
    }

    public virtual async Task AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default
    )
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
        // SaveChanges will be handled by UnitOfWork
    }

    public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        // SaveChanges will be handled by UnitOfWork
        return Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (entity != null)
            await DeleteAsync(entity, cancellationToken);
    }

    public virtual Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        // SaveChanges will be handled by UnitOfWork
        return Task.CompletedTask;
    }

    public Task DeleteRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default
    )
    {
        _dbSet.RemoveRange(entities);
        // SaveChanges will be handled by UnitOfWork
        return Task.CompletedTask;
    }

    public virtual async Task<bool> DoesExistAsync(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await _dbSet.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
}
