using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IClassifiersRepository<TClassifier, TKey> : IRepository<TClassifier, TKey>
    where TClassifier : BaseClassifier<TKey>
    where TKey : struct
{
    Task<TClassifier?> GetByNameAsync(string name, TKey? excludeId, CancellationToken cancellationToken = default);
    
    Task<List<TClassifier>> GetAllByNamesAsynс(IEnumerable<string> names, CancellationToken cancellationToken = default);
}
