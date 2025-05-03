namespace Andromeda.Application.Shared.Quotations.GetItem;

public class GetQuotationItemResponse
{
    public required Guid Id { get; init; }
    public required Guid? ItemId { get; init; }
    
    public required Guid? ProductId { get; init; }
    public required string Description { get; init; }
    public required int Quantity { get; init; }
}