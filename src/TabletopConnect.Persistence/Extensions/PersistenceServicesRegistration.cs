using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TabletopConnect.Persistence.Database;

namespace TabletopConnect.Persistence.Extensions;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TabletopDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        // add more repositories

        return services;
    }
}
