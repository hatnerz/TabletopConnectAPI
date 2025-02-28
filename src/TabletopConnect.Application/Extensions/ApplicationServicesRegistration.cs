using Microsoft.Extensions.DependencyInjection;
using TabletopConnect.Application.Services;
using TabletopConnect.Application.Services.Interfaces;

namespace TabletopConnect.Application.Extensions;

public static class ApplicationServicesRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<ICategoriesService, CategoriesService>();
        services.AddScoped<IFamiliesService, FamiliesService>();
        services.AddScoped<IDesignersService, DesignersService>();
        services.AddScoped<IPublishersService, PublishersService>();
        services.AddScoped<IMechanicsService, MechanicsService>();
        services.AddScoped<ISubcategoriesService, SubcategoriesService>();
        services.AddScoped<IThemesService, ThemesService>();
        services.AddScoped<IBoardGamesService, BoardGamesService>();
    }
}
