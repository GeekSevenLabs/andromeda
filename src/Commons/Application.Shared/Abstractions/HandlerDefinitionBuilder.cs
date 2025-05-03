using FluentValidation;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public interface IHandlerDefinitionBuilder<TRequest> where TRequest : class, IRequest
{
    
    #region OpenAPI
    IHandlerDefinitionBuilder<TRequest> WithName(string name);
    IHandlerDefinitionBuilder<TRequest> WithDescription(string description);
    IHandlerDefinitionBuilder<TRequest> WithTag(string tag);
    #endregion
    
    #region Endpoint
    IHandlerDefinitionBuilder<TRequest> UseMapGet([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest> UseMapPost([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest> UseMapPut([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest> UseMapDelete([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest> UseRouteBuilder(Func<TRequest, string> routeBuilder);
    #endregion
    
    #region Validation
    IHandlerDefinitionBuilder<TRequest> RequireValidation<TValidator>() where TValidator : IValidator<TRequest>;
    #endregion
    
    #region Authorization
    IHandlerDefinitionBuilder<TRequest> RequireAuthorization();
    IHandlerDefinitionBuilder<TRequest> AllowAnonymous();
    #endregion
    
    IHandlerDefinitionBuilder<TRequest> AddMetadata(string key, object value);
    HandlerDefinition<TRequest> Build();
}

public interface IHandlerDefinitionBuilder<TRequest, TResponse> where TRequest : class, IRequest<TResponse> where TResponse : class 
{
    #region OpenAPI
    IHandlerDefinitionBuilder<TRequest, TResponse> WithName(string name);
    IHandlerDefinitionBuilder<TRequest, TResponse> WithDescription(string description);
    IHandlerDefinitionBuilder<TRequest, TResponse> WithTag(string tag);
    #endregion
    
    #region Endpoint
    IHandlerDefinitionBuilder<TRequest, TResponse> UseMapGet([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest, TResponse> UseMapPost([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest, TResponse> UseMapPut([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest, TResponse> UseMapDelete([StringSyntax(StringSyntaxAttribute.Uri)] string route);
    IHandlerDefinitionBuilder<TRequest, TResponse> UseRouteBuilder(Func<TRequest, string> routeBuilder);
    #endregion
    
    #region Validation
    IHandlerDefinitionBuilder<TRequest, TResponse> RequireValidation<TValidator>() where TValidator : IValidator<TRequest>;
    #endregion
    
    #region Authorization
    IHandlerDefinitionBuilder<TRequest, TResponse> RequireAuthorization();
    IHandlerDefinitionBuilder<TRequest, TResponse> AllowAnonymous();
    #endregion
    
    IHandlerDefinitionBuilder<TRequest, TResponse> AddMetadata(string key, object value);
    HandlerDefinition<TRequest, TResponse> Build();
}

public class HandlerDefinitionBuilder<TRequest> : IHandlerDefinitionBuilder<TRequest> where TRequest : class, IRequest
{
    private readonly HandlerDefinition<TRequest> _handlerDefinition = new();
    
    public static IHandlerDefinitionBuilder<TRequest> Create() => new HandlerDefinitionBuilder<TRequest>();

    public IHandlerDefinitionBuilder<TRequest> WithName(string name)
    {
        _handlerDefinition.Name = name;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest> WithDescription(string description)
    {
        _handlerDefinition.Description = description;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest> WithTag(string tag)
    {
        _handlerDefinition.Tag = tag;
        return this;
    }


    public IHandlerDefinitionBuilder<TRequest> UseMapGet(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Get;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest> UseMapPost(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Post;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest> UseMapPut(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Put;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest> UseMapDelete(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Delete;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest> UseRouteBuilder(Func<TRequest, string> routeBuilder)
    {
        _handlerDefinition.BuilderRouteRequest = routeBuilder;
        return this;
    }


    public IHandlerDefinitionBuilder<TRequest> RequireValidation<TValidator>() where TValidator : IValidator<TRequest>
    {
        _handlerDefinition.RequireValidation = true;
        _handlerDefinition.ValidatorType = typeof(TValidator);
        return this;
    }
    
    
    public IHandlerDefinitionBuilder<TRequest> RequireAuthorization()
    {
        _handlerDefinition.RequireAuthorization = true;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest> AllowAnonymous()
    {
        _handlerDefinition.RequireAuthorization = false;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest> AddMetadata(string key, object value)
    {
        _handlerDefinition.Metadata[key] = value;
        return this;
    }

    public HandlerDefinition<TRequest> Build() => _handlerDefinition;
}

public class HandlerDefinitionBuilder<TRequest, TResponse> : IHandlerDefinitionBuilder<TRequest, TResponse> where TRequest : class, IRequest<TResponse> where TResponse : class
{
    private readonly HandlerDefinition<TRequest, TResponse> _handlerDefinition = new();
    public static IHandlerDefinitionBuilder<TRequest, TResponse> Create() => new HandlerDefinitionBuilder<TRequest, TResponse>();
    
    public IHandlerDefinitionBuilder<TRequest, TResponse> WithName(string name)
    {
        _handlerDefinition.Name = name;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest, TResponse> WithDescription(string description)
    {
        _handlerDefinition.Description = description;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest, TResponse> WithTag(string tag)
    {
        _handlerDefinition.Tag = tag;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest, TResponse> UseMapGet(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Get;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest, TResponse> UseMapPost(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Post;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest, TResponse> UseMapPut(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Put;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest, TResponse> UseMapDelete(string route)
    {
        _handlerDefinition.HttpMethod = EndpointMethod.Delete;
        _handlerDefinition.HttpRoute = route;
        return this;
    }
    public IHandlerDefinitionBuilder<TRequest, TResponse> UseRouteBuilder(Func<TRequest, string> routeBuilder)
    {
        _handlerDefinition.BuilderRouteRequest = routeBuilder;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest, TResponse> RequireValidation<TValidator>() where TValidator : IValidator<TRequest>
    {
        _handlerDefinition.RequireValidation = true;
        _handlerDefinition.ValidatorType = typeof(TValidator);
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest, TResponse> RequireAuthorization()
    {
        _handlerDefinition.RequireAuthorization = true;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest, TResponse> AllowAnonymous()
    {
        _handlerDefinition.RequireAuthorization = false;
        return this;
    }

    public IHandlerDefinitionBuilder<TRequest, TResponse> AddMetadata(string key, object value)
    {
        _handlerDefinition.Metadata[key] = value;
        return this;
    }

    public HandlerDefinition<TRequest, TResponse> Build() => _handlerDefinition;
}