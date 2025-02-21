using System.ComponentModel.DataAnnotations;
using TabletopConnect.API.Controllers;

namespace TabletopConnect.API.Extensions;

public static class EndpointRegistration
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapCategoryEndpoints();
    }
}