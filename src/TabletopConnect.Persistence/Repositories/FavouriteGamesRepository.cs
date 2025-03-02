using Microsoft.EntityFrameworkCore;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class FavouriteGamesRepository : Repository<FavouriteGame, int>, IFavouriteGamesRepository
{
    public FavouriteGamesRepository(TabletopDbContext dbContext) : base(dbContext)
    {
    }

    public Task<FavouriteGame?> GetByPlayerAndGameIds(int playerProfileId, int boardGameId, CancellationToken cancellationToken = default)
    {
        return _set.FirstOrDefaultAsync(
            fg => fg.PlayerProfileId == playerProfileId && fg.BoardGameId == boardGameId, cancellationToken);
    }
}
