using Andromeda.Application.Shared.Customers.Edit;
using Andromeda.Application.Shared.Customers.Get;
using Andromeda.Application.Shared.Customers.List;
using Andromeda.Application.Shared.Customers.Remove;

namespace Andromeda.Application.Shared.Customers;

public class CustomerViewService(IEndpointService endpointService) : ICustomerViewService
{
    public async Task EditAsync(EditCustomerRequest request)
    {
        await endpointService.PostAsync(AndromedaHandlerDefinitions.Customers.EditCustomer, request);
    }

    public async Task<GetCustomerResponse> GetAsync(GetCustomerRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.Customers.GetCustomer, request);
    }

    public async Task<ListCustomersResponseItem[]> ListAsync(ListCustomersRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.Customers.ListCustomers, request);
    }

    public async Task RemoveAsync(RemoveCustomerRequest request)
    {
        await endpointService.PostAsync(AndromedaHandlerDefinitions.Customers.RemoveCustomer, request);
    }
}