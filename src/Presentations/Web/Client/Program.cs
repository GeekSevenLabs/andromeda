using Andromeda;
using Andromeda.Application.Shared.Customers;
using Andromeda.Application.Shared.Products;
using Andromeda.Application.Shared.Quotations;
using Andromeda.Application.Shared.RawMaterials;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

FluentValidation.ValidatorOptions.Global.LanguageManager.Culture = CultureHelper.Brazilian;

// Base Services
builder.Services.ConfigureLoaderOptions();
builder.Services.AddCommonClientServices(builder.HostEnvironment.BaseAddress);

// View Services
builder.Services.AddScoped<ICustomerViewService, CustomerViewService>();
builder.Services.AddScoped<IProductViewService, ProductViewService>();
builder.Services.AddScoped<IQuotationViewService, QuotationViewService>();
builder.Services.AddScoped<IRawMaterialViewService, RawMaterialViewService>();

await builder.Build().RunAsync();
