using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public interface IHandlerRegistry
{
    IHandlerRegistry Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler, TRequest, TResponse>(
        HandlerDefinition<TRequest, TResponse> definition) 
        where THandler : class, IHandler<TRequest, TResponse> 
        where TRequest : class, IRequest<TResponse> 
        where TResponse : class;
    
    IHandlerRegistry Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler, TRequest>(
        HandlerDefinition<TRequest> definition) 
        where THandler : class, IHandler<TRequest> 
        where TRequest : class, IRequest;
}

