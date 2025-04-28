using Andromeda.Application;
using Andromeda.Application.Customers;
using Andromeda.Application.Products;
using Andromeda.Application.Quotations;
using Andromeda.Application.RawMaterials;
using Andromeda.Domain;
using Andromeda.Domain.Customers;
using Andromeda.Domain.Products;
using Andromeda.Domain.Quotations;
using Andromeda.Domain.RawMaterials;
using Andromeda.Infrastructure.Contexts;
using Andromeda.Infrastructure.Queries;
using Andromeda.Infrastructure.Repositories;
using Andromeda.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Andromeda.IoC.Extensions;

internal static class InfrastructureExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<AndromedaDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AndromedaDbConnection"));
        });

        // Suporte services
        services.AddScoped<IAndromedaUnitOfWork>(sp => sp.GetRequiredService<AndromedaDbContext>());
        
        // Repositories
        services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IQuotationRepository, QuotationRepository>();
        
        // Queries
        services.AddScoped<IRawMaterialQueries, RawMaterialQueries>();
        services.AddScoped<IProductQueries, ProductQueries>();
        services.AddScoped<ICustomerQueries, CustomerQueries>();
        services.AddScoped<IQuotationQueries, QuotationQueries>();
        
        // Services
        services.AddScoped<IPricingService, PricingService>();
    }
}