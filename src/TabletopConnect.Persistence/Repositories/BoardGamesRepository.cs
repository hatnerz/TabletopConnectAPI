using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class BoardGamesRepository : Repository<BoardGame, int>, IBoardGamesRepository
{
    public BoardGamesRepository(TabletopDbContext context) : base(context)
    {
    }
}
