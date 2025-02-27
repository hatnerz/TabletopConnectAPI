using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application;

public class ThemesService : ClassifierService<Theme>, IThemesService
{
    public ThemesService(IClassifiersRepository<Theme, int> repository, IUnitOfWork unitOfWork)
        : base(repository, unitOfWork)
    {
    }
}
