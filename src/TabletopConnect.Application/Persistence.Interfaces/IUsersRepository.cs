using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Domain.Entities.IAM;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IUsersRepository : IRepository<User, int>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User?> GetByGoogleIdAsync(string googleId, CancellationToken cancellationToken);
    Task<PlayerProfile?> GetLinkedPlayerProfile(int userId, CancellationToken cancellationToken);
}
