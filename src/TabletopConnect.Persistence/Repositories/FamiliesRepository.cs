using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class FamiliesRepository : Repository<Family, int>, IFamiliesRepository
{
    public FamiliesRepository(TabletopDbContext context) : base(context)
    {
    }
}
