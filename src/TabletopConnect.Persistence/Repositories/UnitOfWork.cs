using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly TabletopDbContext _dbContext;

    public UnitOfWork(TabletopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
