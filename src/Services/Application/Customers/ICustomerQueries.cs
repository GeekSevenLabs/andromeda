using Andromeda.Application.Shared.Customers.Get;
using Andromeda.Application.Shared.Customers.List;

namespace Andromeda.Application.Customers;

public interface ICustomerQueries
{
    Task<GetCustomerResponse?> GetAsync(Guid id);
    Task<ListCustomersResponseItem[]> ListAsync(string? term);
}