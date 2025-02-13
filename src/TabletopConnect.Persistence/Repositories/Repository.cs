using Microsoft.EntityFrameworkCore;
using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Persistence.Repositories;

internal abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : struct
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _set;
    protected readonly IQueryable<TEntity> _readonlySet;

    protected Repository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _set = _context.Set<TEntity>();
        _readonlySet = _set.AsNoTracking();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _set.FindAsync([id], cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _set.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdReadOnlyAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _readonlySet.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
    }

    public async Task<List<TEntity>> GetAllReadOnlyAsync(CancellationToken cancellationToken = default)
    {
        return await _readonlySet.ToListAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        _set.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _set.AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        _set.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _set.RemoveRange(entities);
    }

    public async Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _set.AnyAsync(e => e.Id.Equals(id), cancellationToken);
    }
}
