namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

    // TODO ADD Transactions
}
