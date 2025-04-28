namespace Andromeda.Application.Shared.Customers.List;

public class ListCustomersResponseItem
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Phone { get; init; }
    public required string Email { get; init; }
}