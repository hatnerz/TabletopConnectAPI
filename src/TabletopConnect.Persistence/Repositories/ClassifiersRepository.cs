using Microsoft.EntityFrameworkCore;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class ClassifiersRepository<TEntity, TKey> : Repository<TEntity, TKey>, IClassifiersRepository<TEntity, TKey>
    where TEntity : BaseClassifier<TKey>
    where TKey : struct
{
    public ClassifiersRepository(TabletopDbContext context) : base(context)
    {
    }

    public Task<List<TEntity>> GetAllByNamesAsynс(IEnumerable<string> names, CancellationToken cancellationToken = default)
    {
        return _set.Where(e => names.Contains(e.Name)).ToListAsync(cancellationToken);
    }

    public Task<TEntity?> GetByNameAsync(string name, TKey? excludeId, CancellationToken cancellationToken = default)
    {
        return _set.FirstOrDefaultAsync(e => e.Name == name && (excludeId == null || !e.Id.Equals(excludeId)));
    }
}
