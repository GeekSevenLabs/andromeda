using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public abstract class HandlerDefinitionBase
{

    #region OpenAPI

    public string Name { get; internal set; } = string.Empty;
    public string Description { get; internal set; } = string.Empty;
    public string Tag { get; internal set; } = string.Empty;

    #endregion
    
    #region Endpoint
    
    public EndpointMethod HttpMethod { get; internal set; }
    public string HttpRoute { get; internal set; } = string.Empty;
    
    #endregion
    
    #region Validation

    [MemberNotNullWhen(true, nameof(ValidatorType))]
    public bool RequireValidation { get; internal set; }
    public Type? ValidatorType { get; internal set; }
    
    #endregion
    
    #region Authorization
    
    public bool RequireAuthorization { get; internal set; }
    
    #endregion

    public Dictionary<string, object?> Metadata { get; } = [];
    
}

public class HandlerDefinition<TRequest> : HandlerDefinitionBase where TRequest : class, IRequest
{
    #region Endpoint

    public Func<TRequest, string> BuilderRouteRequest { get; internal set; } = _ => string.Empty;

    #endregion
}

public class HandlerDefinition<TRequest, TResponse> : HandlerDefinitionBase where TRequest : class, IRequest<TResponse> where TResponse : class
{
    #region Endpoint

    public Func<TRequest, string> BuilderRouteRequest { get; internal set; } = _ => string.Empty;

    #endregion
}