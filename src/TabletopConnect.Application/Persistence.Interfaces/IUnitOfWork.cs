namespace TabletopConnect.Application.Persistence.Interfaces;

internal interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
