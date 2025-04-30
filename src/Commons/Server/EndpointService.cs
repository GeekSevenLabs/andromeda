using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Andromeda;

public class EndpointService(IServiceProvider provider) : IEndpointService
{
    public async Task PostAsync<TRequest>(HandlerDefinition<TRequest> definition, TRequest request) where TRequest : class, IRequest
    {
        if (definition.RequireValidation)
        {
            var validator = provider.GetRequiredService<IValidator<TRequest>>();
            await validator.ValidateAndThrowAsync(request);
        }
        
        var handler = provider.GetRequiredService<IHandler<TRequest>>();
        await handler.HandleAsync(request);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        if (definition.RequireValidation)
        {
            var validator = provider.GetRequiredService<IValidator<TRequest>>();
            await validator.ValidateAndThrowAsync(request);
        }
        
        var handler = provider.GetRequiredService<IHandler<TRequest, TResponse>>();
        return await handler.HandleAsync(request);
    }

    public async Task<TResponse> GetAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        if (definition.RequireValidation)
        {
            var validator = provider.GetRequiredService<IValidator<TRequest>>();
            await validator.ValidateAndThrowAsync(request);
        }
        
        var handler = provider.GetRequiredService<IHandler<TRequest, TResponse>>();
        return await handler.HandleAsync(request);
    }

    public async Task<TResponse> PutAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        if (definition.RequireValidation)
        {
            var validator = provider.GetRequiredService<IValidator<TRequest>>();
            await validator.ValidateAndThrowAsync(request);
        }
        
        var handler = provider.GetRequiredService<IHandler<TRequest, TResponse>>();
        return await handler.HandleAsync(request);
    }

    public async Task<TResponse> DeleteAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        if (definition.RequireValidation)
        {
            var validator = provider.GetRequiredService<IValidator<TRequest>>();
            await validator.ValidateAndThrowAsync(request);
        }
        
        var handler = provider.GetRequiredService<IHandler<TRequest, TResponse>>();
        return await handler.HandleAsync(request);
    }

    public async Task DeleteAsync<TRequest>(HandlerDefinition<TRequest> definition, TRequest request) where TRequest : class, IRequest
    {
        if (definition.RequireValidation)
        {
            var validator = provider.GetRequiredService<IValidator<TRequest>>();
            await validator.ValidateAndThrowAsync(request);
        }
        
        var handler = provider.GetRequiredService<IHandler<TRequest>>();
        await handler.HandleAsync(request);
    }
}