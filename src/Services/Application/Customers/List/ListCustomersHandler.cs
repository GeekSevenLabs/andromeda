using Andromeda.Application.Shared.Customers.List;

namespace Andromeda.Application.Customers.List;

public class ListCustomersHandler(ICustomerQueries queries) : IHandler<ListCustomersRequest, ListCustomersResponseItem[]>
{
    public async Task<ListCustomersResponseItem[]> HandleAsync(ListCustomersRequest request, CancellationToken cancellationToken = default)
    {
        return await queries.ListAsync(request.Term);
    }
}