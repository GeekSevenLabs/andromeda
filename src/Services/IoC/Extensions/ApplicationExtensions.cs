using Andromeda.Application;
using Andromeda.Application.Shared;
using Andromeda.Application.Shared.Customers;
using Andromeda.Application.Shared.Products;
using Andromeda.Application.Shared.Quotations;
using Andromeda.Application.Shared.RawMaterials;
using Microsoft.Extensions.DependencyInjection;

namespace Andromeda.IoC.Extensions;

internal static class ApplicationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddHandlersServices(AndromedaHandlerRegistry.Register);
        
        // Register the application services
        services.AddScoped<ICustomerViewService, CustomerViewService>();
        services.AddScoped<IProductViewService, ProductViewService>();
        services.AddScoped<IQuotationViewService, QuotationViewService>();
        services.AddScoped<IRawMaterialViewService, RawMaterialViewService>();
    }
}