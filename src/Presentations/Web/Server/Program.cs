using Andromeda;
using Andromeda.Extensions;
using Andromeda.IoC;
using Andromeda.Presentation.Web.Components;
using Andromeda.Presentation.Web.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

FluentValidation.ValidatorOptions.Global.LanguageManager.Culture = CultureHelper.Brazilian;

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCommonServerServices();
builder.AddAndromedaOpenApiServices();
builder.AddAndromedaServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.MapOpenApi();
    app.MapScalarApiReference();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.UseAndromeda();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Andromeda.Presentation.Web.Client._Imports).Assembly);

app.Run();