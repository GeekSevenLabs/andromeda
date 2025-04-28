using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Andromeda;

public class HandlerServiceRegistry(IServiceCollection services) : IHandlerRegistry
{
    public IHandlerRegistry Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler, TRequest, TResponse>(
        HandlerDefinition<TRequest, TResponse> definition) 
        where THandler : class, IHandler<TRequest, TResponse> 
        where TRequest : class, IRequest<TResponse> 
        where TResponse : class
    {
        services.AddTransient<IHandler<TRequest, TResponse>, THandler>();

        if (definition.RequireValidation)
        {
            services.AddTransient(typeof(IValidator<TRequest>), definition.ValidatorType);
        }
        
        return this;
    }

    public IHandlerRegistry Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler, TRequest>(
        HandlerDefinition<TRequest> definition)
        where THandler : class, IHandler<TRequest> 
        where TRequest : class, IRequest
    {
        services.AddTransient<IHandler<TRequest>, THandler>();
        
        if (definition.RequireValidation)
        {
            services.AddTransient(typeof(IValidator<TRequest>), definition.ValidatorType);
        }
        
        return this;
    }
}