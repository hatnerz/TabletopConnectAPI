using Microsoft.Extensions.DependencyInjection;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Infrastructure.Authentication;
using TabletopConnect.Infrastructure.DataImporters;
using TabletopConnect.Infrastructure.Security;
using TabletopConnect.Infrastructure.Services;

namespace TabletopConnect.Infrastructure.Extensions;

public static class InfrastructureServicesRegistration
{
    public static void AddInfrastructureService(this IServiceCollection services)
    {
        services.AddTransient<IBoardGamesCsvImportService, BoardGamesCsvImportService>();
        services.AddScoped<IGoogleAuthService, GoogleAuthService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
    }
}
