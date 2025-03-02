using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Persistence.Database;
using TabletopConnect.Persistence.DataSeeders;
using TabletopConnect.Persistence.Repositories;

namespace TabletopConnect.Persistence.Extensions;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentException("Connection string not specified");

        services.AddDbContext<TabletopDbContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseSeeding((context, _) =>
                {
                    var servicesProvider = services.BuildServiceProvider().CreateScope().ServiceProvider;

                    var importService = servicesProvider.GetService<IBoardGamesCsvImportService>() ?? throw new InvalidOperationException("BoardGamesCsvImportService not found.");

                    var seeder = new CsvDataSeeder(configuration, importService, context);

                    seeder.SeedBoardGameWithCategories();
                    seeder.SeedDesigners();
                    seeder.SeedMechanics();
                    seeder.SeedSubcategories();
                    seeder.SeedPublishers();
                    seeder.SeedThemes();
                });
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBoardGamesRepository, BoardGamesRepository>();
        services.AddScoped(typeof(IClassifiersRepository<,>), typeof(ClassifiersRepository<,>));
        services.AddScoped(typeof(IBoardGameRelatedClassifierRepository<,>), typeof(BoardGameRelatedClassifierRepository<,>));
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IPlayerProfilesRepository, PlayerProfilesRepository>();
        services.AddScoped<IFavouriteGamesRepository, FavouriteGamesRepository>();

        return services;
    }
}
