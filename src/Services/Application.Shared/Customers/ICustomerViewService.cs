using Andromeda.Application.Shared.Customers.Edit;
using Andromeda.Application.Shared.Customers.Get;
using Andromeda.Application.Shared.Customers.List;
using Andromeda.Application.Shared.Customers.Remove;

namespace Andromeda.Application.Shared.Customers;

public interface ICustomerViewService
{
    Task EditAsync(EditCustomerRequest request);
    Task<GetCustomerResponse> GetAsync(GetCustomerRequest request);
    Task<ListCustomersResponseItem[]> ListAsync(ListCustomersRequest request);
    Task RemoveAsync(RemoveCustomerRequest request);
}