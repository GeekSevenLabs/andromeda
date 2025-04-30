namespace Andromeda;

public interface IEndpointService
{
    Task PostAsync<TRequest>(HandlerDefinition<TRequest> definition, TRequest request) where TRequest : class, IRequest;
    Task<TResponse> PostAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class;
    
    Task<TResponse> GetAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class;
    
    Task<TResponse> PutAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class;
    
    Task<TResponse> DeleteAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class;
    Task DeleteAsync<TRequest>(HandlerDefinition<TRequest> definition, TRequest request) where TRequest : class, IRequest;
}