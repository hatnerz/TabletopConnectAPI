using Microsoft.Extensions.DependencyInjection;
using TabletopConnect.Application.Services;
using TabletopConnect.Application.Services.Interfaces;

namespace TabletopConnect.Application.Extensions;

public static class ApplicationServicesRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoriesService, CategoriesService>();
        //services.AddScoped<IGameFamiliesService, GameFamiliesService>();
        //services.AddScoped<IGameDesignersService, GameDesignersService>();
        //services.AddScoped<ICategoriesService, CategoriesService>();
        //services.AddScoped<IMechanicsService, MechanicsService>();
    }
}
