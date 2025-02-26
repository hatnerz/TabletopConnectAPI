using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class PlayerProfilesRepository : Repository<PlayerProfile, int>, IPlayerProfilesRepository
{
    public PlayerProfilesRepository(TabletopDbContext context) : base(context)
    {
    }
}
