using Andromeda.Application.Shared.Quotations.GetItem;

namespace Andromeda.Application.Shared.Quotations.EditeItem;

public class EditQuotationItemRequest : IRequest
{
    public Guid Id { get; set; }
    public Guid? ItemId { get; set; }
    
    public Guid? ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    
    public void CopyFrom(GetQuotationItemResponse response)
    {
        Id = response.Id;
        ItemId = response.ItemId;
        ProductId = response.ProductId;
        Description = response.Description;
        Quantity = response.Quantity;
    }
    
}