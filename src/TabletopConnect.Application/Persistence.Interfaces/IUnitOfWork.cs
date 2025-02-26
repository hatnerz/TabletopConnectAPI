namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    // TODO ADD Transactions
}
