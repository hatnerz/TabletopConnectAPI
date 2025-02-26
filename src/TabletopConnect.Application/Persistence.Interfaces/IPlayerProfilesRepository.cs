using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IPlayerProfilesRepository : IRepository<PlayerProfile, int>
{
}
