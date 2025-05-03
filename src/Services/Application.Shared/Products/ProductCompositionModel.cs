namespace Andromeda.Application.Shared.Products;

public class ProductCompositionModel
{
    public Guid? Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public int? Quantity { get; set; }
    
    public Guid? RawMaterialId { get; set; }
    public bool RawMaterialIsDeleted { get; set; }


    public void CopyFrom(ProductCompositionModel model)
    {
        Id = model.Id;
        Description = model.Description;
        Quantity = model.Quantity;
        RawMaterialId = model.RawMaterialId;
        RawMaterialIsDeleted = model.RawMaterialIsDeleted;
    }
    
    public void ResetRawMaterialWhenDeleted()
    {
        if (!RawMaterialIsDeleted) return;
        RawMaterialId = null;
        RawMaterialIsDeleted = false;
    }
}