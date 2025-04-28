using Andromeda.Application.Shared.Products;
using Andromeda.Application.Shared.Products.Get;
using Andromeda.Application.Shared.Products.List;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public class DeiProductSelectorField : DeiSelectorAbstractField<Guid>
{
    public DeiProductSelectorField()
    {
        Clearable = true;
        Label = "Produto";
        Placeholder = "Selecione um produto";
    }
    
    [Inject] public required IProductViewService ViewService { get; set; }
    
    protected override Func<string, Task<ChoiceOption<Guid>[]>> ItemsSearch => SearchAsync;
    protected override Func<Guid, Task<ChoiceOption<Guid>>> ItemRecover => RecoverAsync;
    
    private async Task<ChoiceOption<Guid>> RecoverAsync(Guid id)
    {
        var product = await ViewService.GetAsync(new GetProductRequest { Id = id});
        return new ChoiceOption<Guid>(id, product.Name);
    }
    
    private async Task<ChoiceOption<Guid>[]> SearchAsync(string term)
    {
        var request = new ListProductsRequest { Term = term };
        var products = await ViewService.ListAsync(request);
        
        return products
            .Select(p => new ChoiceOption<Guid>(p.Id, p.Name))
            .ToArray();
    }
    
}