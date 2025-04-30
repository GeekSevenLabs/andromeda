using System.Net.Http.Json;

namespace Andromeda.Services;

internal class EndpointService(HttpClient client) : IEndpointService
{
    public async Task PostAsync<TRequest>(HandlerDefinition<TRequest> definition, TRequest request) where TRequest : class, IRequest
    {
        var route = definition.BuilderRouteRequest(request);
        var response = await client.PostAsJsonAsync(route, request);
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        var route = definition.BuilderRouteRequest(request);
        var response = await client.PostAsJsonAsync(route, request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>() ?? throw new InvalidOperationException("Response content is null.");
    }

    public async Task<TResponse> GetAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        var route = definition.BuilderRouteRequest(request);
        var response = await client.GetAsync(route);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>() ?? throw new InvalidOperationException("Response content is null.");
    }

    public async Task<TResponse> PutAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        var route = definition.BuilderRouteRequest(request);
        var response = await client.PutAsJsonAsync(route, request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>() ?? throw new InvalidOperationException("Response content is null.");
    }

    public async Task<TResponse> DeleteAsync<TRequest, TResponse>(HandlerDefinition<TRequest, TResponse> definition, TRequest request) where TRequest : class, IRequest<TResponse> where TResponse : class
    {
        var route = definition.BuilderRouteRequest(request);
        var response = await client.DeleteAsync(route);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>() ?? throw new InvalidOperationException("Response content is null.");
    }

    public async Task DeleteAsync<TRequest>(HandlerDefinition<TRequest> definition, TRequest request) where TRequest : class, IRequest
    {
        var route = definition.BuilderRouteRequest(request);
        var response = await client.DeleteAsync(route);
        response.EnsureSuccessStatusCode();
    }
}