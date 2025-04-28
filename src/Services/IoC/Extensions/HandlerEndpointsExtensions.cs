using Andromeda.Application;
using Microsoft.AspNetCore.Routing;

namespace Andromeda.IoC.Extensions;

internal static class HandlerEndpointsExtensions
{
    public static void MapAndromedaHandlerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHandlerEndpoints(AndromedaHandlerRegistry.Register);
    }
}