using Andromeda.Services.Ui;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace Andromeda.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonServerServices(this IServiceCollection services)
    {
        services.AddProblemDetails();
        
        services.AddExceptionHandler<ExceptionToProblemDetailsHandler>();
        
        services.AddScoped<IEndpointService, EndpointService>();
        services.AddScoped<IUiUtils, UiUtils>();
        
        services.AddMudServices();
        return services;
    }
}