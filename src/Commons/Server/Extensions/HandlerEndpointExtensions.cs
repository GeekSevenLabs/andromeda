using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public static class HandlerEndpointExtensions
{
    public static void AddHandlersServices(this IServiceCollection services, params Action<IHandlerRegistry>[] actions)
    {
        Register(new HandlerServiceRegistry(services), actions);
    }

    public static void MapHandlerEndpoints(this IEndpointRouteBuilder builder, params Action<IHandlerRegistry>[] actions)
    {
        Register(new HandlerEndpointRegistry(builder), actions);
    }

    private static void Register(IHandlerRegistry registry, Action<IHandlerRegistry>[] actions)
    {
        foreach (var action in actions)
        {
            action(registry);       
        }
    }
}