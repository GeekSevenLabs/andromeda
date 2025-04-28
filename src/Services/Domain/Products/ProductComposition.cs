namespace Andromeda.Domain.Products;

public class ProductComposition : Entity
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private ProductComposition() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public ProductComposition(Guid productId, Guid rawMaterialId, string description, int quantity)
    {
        ProductId = productId;
        RawMaterialId = rawMaterialId;
        Description = description;
        Quantity = quantity;
    }
    
    public Guid ProductId { get; private set; }
    public Guid RawMaterialId { get; private set; }
    
    public string Description { get; private set; }
    public int Quantity { get; private set; }
    
    public void ChangeDescription(string description) => Description = description;
    public void ChangeQuantity(int quantity) => Quantity = quantity;
}