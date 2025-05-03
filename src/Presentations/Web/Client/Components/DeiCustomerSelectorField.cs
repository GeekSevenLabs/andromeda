using Andromeda.Application.Shared.Customers;
using Andromeda.Application.Shared.Customers.Get;
using Andromeda.Application.Shared.Customers.List;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public class DeiCustomerSelectorField : DeiSelectorAbstractField<Guid>
{
    public DeiCustomerSelectorField()
    {
        Clearable = true;
        Label = "Cliente";
        Placeholder = "Selecione um cliente";
    }
    
    [Inject] public required ICustomerViewService ViewService { get; set; }
    
    protected override Func<string, Task<ChoiceOption<Guid>[]>> ItemsSearch => SearchAsync;
    protected override Func<Guid, Task<ChoiceOption<Guid>>> ItemRecover => RecoverAsync;
    
    private async Task<ChoiceOption<Guid>> RecoverAsync(Guid id)
    {
        // var customer = await EndpointService.RequestAsync(new GetCustomerEndpoint(), id);
        var customer = await ViewService.GetAsync(new GetCustomerRequest { Id = id });
        return new ChoiceOption<Guid>(id, customer.Name);
    }
    
    private async Task<ChoiceOption<Guid>[]> SearchAsync(string term)
    {
        var request = new ListCustomersRequest { Term = term };
        var customers = await ViewService.ListAsync(request);
        
        return customers
            .Select(c => new ChoiceOption<Guid>(c.Id, c.Name))
            .ToArray();
    }
}