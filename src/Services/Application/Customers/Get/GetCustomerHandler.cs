using Andromeda.Application.Shared.Customers.Get;

namespace Andromeda.Application.Customers.Get;

public class GetCustomerHandler(ICustomerQueries queries) : IHandler<GetCustomerRequest, GetCustomerResponse>
{
    public async Task<GetCustomerResponse> HandleAsync(GetCustomerRequest request, CancellationToken cancellationToken = default)
    {
        var customer = await queries.GetAsync(request.Id);
        Throw.Http.NotFound.When.Null(customer, "Cliente não encontrado.");
        return customer;
    }
}