using Andromeda.IoC.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Andromeda.IoC;

public static class OrchestratorExtensions
{
    public static void AddAndromedaServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
    }

    public static void UseAndromeda(this WebApplication app)
    {
        app.MapAndromedaHandlerEndpoints();
    }
}