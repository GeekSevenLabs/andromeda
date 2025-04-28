namespace Andromeda.Application.Shared.Customers.Get;

public class GetCustomerResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Phone { get; init; }
    public required string Email { get; init; }
}