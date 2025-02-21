using Microsoft.Extensions.DependencyInjection;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Infrastructure.DataImporters;

namespace TabletopConnect.Infrastructure.Extensions;

public static class InfrastructureServicesRegistration
{
    public static void AddInfrastructureService(this IServiceCollection services)
    {
        services.AddTransient<IBoardGamesCsvImportService, BoardGamesCsvImportService>();
    }
}
