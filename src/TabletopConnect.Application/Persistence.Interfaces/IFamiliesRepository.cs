using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IFamiliesRepository : IRepository<Family, int>
{
}
