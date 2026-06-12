using System;
using MultiplayerGames_Server.Domain.Common;

namespace MultiplayerGames_Server.Application.Abstractions.Data.Repositories;

public interface IBaseRepository<T>
    where T : AggregateRoot
{
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    Task<bool> AnyAsync(string Id, CancellationToken cancellationToken);
}
