using Microsoft.OpenApi.Models;

namespace Andromeda.Presentation.Web.Extensions;

public static class OpenApiExtensions
{
    public static void AddAndromedaOpenApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((apiDocument, _, _) =>
            {
                apiDocument.Info.Title = "Andromeda API";
                apiDocument.Info.Description = "API for Andromeda";
                apiDocument.Info.Version = "v1";
                
                apiDocument.Servers = [];
        
                apiDocument.Components ??= new OpenApiComponents();
                // apiDocument.Components.SecuritySchemes = new Dictionary<string, OpenApiSecurityScheme>
                // {
                //     ["Authorization"] = new ()
                //     {
                //         Name = "Authorization",
                //         Type = SecuritySchemeType.Http,
                //         Scheme = JwtBearerDefaults.AuthenticationScheme,
                //         BearerFormat = "JWT",
                //         In = ParameterLocation.Header,
                //         Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
                //     }
                // };
        
                return Task.CompletedTask;
            });
            options.AddOperationTransformer<UseFluentValidatorRulesOperationTransformer>();
        });
        
        builder.Services.AddEndpointsApiExplorer();
    }
}