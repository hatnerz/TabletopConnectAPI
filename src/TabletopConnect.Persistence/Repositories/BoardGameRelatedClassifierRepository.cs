using Microsoft.EntityFrameworkCore;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class BoardGameRelatedClassifierRepository<TRelatedClassifier, TKey> : Repository<TRelatedClassifier, TKey>, IBoardGameRelatedClassifierRepository<TRelatedClassifier, TKey>
    where TRelatedClassifier : BoardGameRelatedClassifier<TKey>
    where TKey : struct
{
    public BoardGameRelatedClassifierRepository(TabletopDbContext context) : base(context)
    {
    }

    public Task<List<TRelatedClassifier>> GetBoardGameRelatedClassifiers(int boardGameId, CancellationToken cancellationToken = default)
    {
        return _set.Where(_set => _set.BoardGameId == boardGameId).ToListAsync(cancellationToken);
    }
}
