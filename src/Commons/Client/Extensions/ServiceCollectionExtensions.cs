using Andromeda.ProblemDetails;
using Andromeda.Services;
using Andromeda.Services.Ui;
using BlazorDevKit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public static class ServiceCollectionExtensions
{
    private const string ServerClientName = "server";
    
    public static IServiceCollection AddCommonClientServices(this IServiceCollection services, string serverAddress)
    {
        services.AddMudServices();
        services.AddScoped<IUiUtils, UiUtils>();

        services.AddScoped<ProblemDetailsExceptionMessageHandler>();

        services
            .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(ServerClientName));

        services
            .AddHttpClient(ServerClientName, client => client.BaseAddress = new Uri(serverAddress))
            .AddHttpMessageHandler<ProblemDetailsExceptionMessageHandler>();

        services.AddScoped<IEndpointService, EndpointService>();

        return services;
    }

    public static void ConfigureLoaderOptions(this IServiceCollection _)
    {
        BdkLoaderOptions.Loading.ChangeContent<DeiLoadingContent>();
        BdkLoaderOptions.Error.RegisterContent<Exception, DeiDefaultErrorContent>();
    }
}