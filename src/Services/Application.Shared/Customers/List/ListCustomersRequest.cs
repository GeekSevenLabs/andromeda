namespace Andromeda.Application.Shared.Customers.List;

public class ListCustomersRequest : IRequest<ListCustomersResponseItem[]>
{
    public string? Term { get; set; }
}