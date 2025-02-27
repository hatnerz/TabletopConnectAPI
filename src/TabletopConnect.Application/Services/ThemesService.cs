using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Services;

public class ThemesService : ClassifierService<Theme>, IThemesService
{
    public ThemesService(IClassifiersRepository<Theme, int> repository, IUnitOfWork unitOfWork)
        : base(repository, unitOfWork)
    {
    }
}
