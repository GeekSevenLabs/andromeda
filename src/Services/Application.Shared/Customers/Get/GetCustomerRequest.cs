namespace Andromeda.Application.Shared.Customers.Get;

public class GetCustomerRequest : IRequest<GetCustomerResponse>
{
    public required Guid Id { get; init; }
}