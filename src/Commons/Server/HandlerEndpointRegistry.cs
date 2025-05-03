using System.Diagnostics.CodeAnalysis;
using Menso.Tools.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Andromeda;

public class HandlerEndpointRegistry(IEndpointRouteBuilder builder) : IHandlerRegistry
{
    public IHandlerRegistry Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler, TRequest, TResponse>(
        HandlerDefinition<TRequest, TResponse> definition) 
        where THandler : class, IHandler<TRequest, TResponse> 
        where TRequest : class, IRequest<TResponse> 
        where TResponse : class
    {
        var endpoint = definition.HttpMethod switch
        {
            EndpointMethod.Get => builder.MapGet(definition.HttpRoute, async ([AsParameters] TRequest request,IHandler<TRequest, TResponse> handler) => await handler.HandleAsync(request)),
            EndpointMethod.Post => builder.MapPost(definition.HttpRoute, async (TRequest request, IHandler<TRequest, TResponse> handler) => await handler.HandleAsync(request)),
            EndpointMethod.Put => builder.MapPut(definition.HttpRoute, async (TRequest request, IHandler<TRequest, TResponse> handler) => await handler.HandleAsync(request)),
            EndpointMethod.Delete => builder.MapDelete(definition.HttpRoute, async ([AsParameters]TRequest request, IHandler<TRequest, TResponse> handler) => await handler.HandleAsync(request)),
            _ => throw new NotSupportedException($"Endpoint method {definition.HttpMethod} is not supported.")
        };

        ApplyEndpointDefinition<TRequest>(endpoint, definition).Produces<TResponse>().ProducesValidationProblem();
        return this;
    }

    public IHandlerRegistry Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler, TRequest>(
        HandlerDefinition<TRequest> definition)
        where THandler : class, IHandler<TRequest> 
        where TRequest : class, IRequest
    {
        Throw.When.Equal(definition.HttpMethod, EndpointMethod.Get, "GET method is not supported for this operation. Use another method instead.");
        
        var endpoint = definition.HttpMethod switch
        {
            EndpointMethod.Post => builder.MapPost(definition.HttpRoute, async (TRequest request, IHandler<TRequest> handler) => await handler.HandleAsync(request)),
            EndpointMethod.Put => builder.MapPut(definition.HttpRoute, async (TRequest request, IHandler<TRequest> handler) => await handler.HandleAsync(request)),
            EndpointMethod.Delete => builder.MapDelete(definition.HttpRoute, async ([AsParameters]TRequest request, IHandler<TRequest> handler) => await handler.HandleAsync(request)),
            _ => throw new NotSupportedException($"Endpoint method {definition.HttpMethod} is not supported.")
        };

        ApplyEndpointDefinition<TRequest>(endpoint, definition).ProducesValidationProblem();
        return this;
    }
    
    private static RouteHandlerBuilder ApplyEndpointDefinition<TRequest>(RouteHandlerBuilder endpoint, HandlerDefinitionBase definition) where TRequest : class
    {
        // OpenAPI
        endpoint
            .WithName(definition.Name)
            .WithTags(definition.Tag)
            .WithDescription(definition.Description);

        // Authorization
        if (!definition.RequireAuthorization)
        {
            endpoint.RequireAuthorization();
        }
        else
        {
            endpoint.AllowAnonymous();
        }
        
        // Validation
        if (definition.RequireValidation)
        {
            endpoint.UseValidationFor<TRequest>();
            
            // Metadata
            var metadata = new HandlerDefinitionMetadata
            {
                Path = definition.HttpRoute,
                RequestType = typeof(TRequest),
                ValidatorType = definition.ValidatorType,
                RequireValidation = definition.RequireValidation,
            };
        
            endpoint.WithMetadata(metadata);
        }

        return endpoint;
    }
}