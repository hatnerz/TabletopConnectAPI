using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface ICategoriesRepository : IClassifiersRepository<Category, int>
{
}
