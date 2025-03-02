using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IFavouriteGamesRepository : IRepository<FavouriteGame, int>
{
    public Task<FavouriteGame?> GetByPlayerAndGameIds(int playerProfileId, int boardGameId, CancellationToken cancellationToken = default);
}
