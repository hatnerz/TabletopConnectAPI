using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IBoardGameRelatedClassifierRepository<TRelatedClassifier, TKey> : IRepository<TRelatedClassifier, TKey>
    where TRelatedClassifier : BoardGameRelatedClassifier<TKey>
    where TKey : struct
{
    Task<List<TRelatedClassifier>> GetBoardGameRelatedClassifiers(int boardGameId, CancellationToken cancellationToken = default);
}
