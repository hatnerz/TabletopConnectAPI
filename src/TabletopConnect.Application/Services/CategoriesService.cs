using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Services;

public class CategoriesService : ClassifierService<Category>, ICategoriesService
{
    public CategoriesService(IClassifiersRepository<Category, int> repository, IUnitOfWork unitOfWork)
        : base(repository, unitOfWork)
    {
    }
}
