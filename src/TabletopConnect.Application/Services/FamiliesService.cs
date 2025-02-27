using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Services;

public class FamiliesService : ClassifierService<Family>, IFamiliesService
{
    public FamiliesService(IClassifiersRepository<Family, int> repository, IUnitOfWork unitOfWork)
        : base(repository, unitOfWork)
    {
    }
}
