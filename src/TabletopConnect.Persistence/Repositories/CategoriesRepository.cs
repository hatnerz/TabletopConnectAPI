using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Repositories;

internal class CategoriesRepository : ClassifiersRepository<Category, int>, ICategoriesRepository
{
    public CategoriesRepository(TabletopDbContext context) : base(context)
    {
    }
}
