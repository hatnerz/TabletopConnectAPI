using System.Collections.Generic;
using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Persistence.Repositories.Common;

public interface IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : struct
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdReadOnlyAsync(TKey id, CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetAllReadonlyAsync(CancellationToken cancellationToken = default);

    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);

    Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken = default);
}
