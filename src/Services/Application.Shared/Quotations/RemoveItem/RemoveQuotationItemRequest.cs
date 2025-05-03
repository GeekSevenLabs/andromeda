namespace Andromeda.Application.Shared.Quotations.RemoveItem;

public class RemoveQuotationItemRequest : IRequest
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
}