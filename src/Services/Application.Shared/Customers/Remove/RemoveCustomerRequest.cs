namespace Andromeda.Application.Shared.Customers.Remove;

public class RemoveCustomerRequest : IRequest
{
    public required Guid Id { get; init; }
}