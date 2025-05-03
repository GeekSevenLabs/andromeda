using Andromeda.Domain.Shared;

namespace Andromeda.Application.Shared.Quotations.List;

public class ListQuotationsResponseItem
{
    public required Guid Id { get; init; }
    
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    
    public required QuotationStatus Status { get; init; }
    public required DateTimeOffset? ValidUntil { get; init; }
    
    public required string CustomerName { get; init; }
    public required string CustomerEmail { get; init; }
    
}