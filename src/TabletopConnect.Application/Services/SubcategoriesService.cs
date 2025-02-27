using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Services;

public class SubcategoriesService : ClassifierService<Subcategory>, ISubcategoriesService
{
    public SubcategoriesService(IClassifiersRepository<Subcategory, int> repository, IUnitOfWork unitOfWork)
        : base(repository, unitOfWork)
    {
    }
}
