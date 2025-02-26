using Microsoft.EntityFrameworkCore;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Domain.Entities.IAM;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class UsersRepository : Repository<User, int>, IUsersRepository
{
    public UsersRepository(TabletopDbContext context) : base(context)
    {
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return _set.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public Task<User?> GetByGoogleIdAsync(string googleId, CancellationToken cancellationToken)
    {
        return _set.FirstOrDefaultAsync(x => x.GoogleId == googleId, cancellationToken);
    }

    public Task<PlayerProfile?> GetLinkedPlayerProfile(int userId, CancellationToken cancellationToken)
    {
        return _context.Set<PlayerProfile>().FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
    }
}
