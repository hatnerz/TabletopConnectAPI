using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IBoardGamesRepository : IRepository<BoardGame, int>
{
}
