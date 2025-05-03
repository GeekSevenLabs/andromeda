namespace Andromeda.Domain.Quotations;

public class QuotationItem : Entity
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private QuotationItem() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public QuotationItem(Guid quotationId, Guid productId, int quantity, decimal pricePerUnit, string description)
    {
        Throw.When.True(quantity < 1, "Quantidade deve ser maior que zero.");
        Throw.When.True(pricePerUnit <= 0, "Preço por unidade deve ser maior que zero.");
        
        QuotationId = quotationId;
        ProductId = productId;
        Quantity = quantity;
        Price = quantity * pricePerUnit;
        PricePerUnit = pricePerUnit;
        Description = description;
    }
    
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal PricePerUnit { get; private set; }
    public string Description { get; private set; }
    
    public Guid ProductId { get; private set; }
    public Guid QuotationId { get; private set; }
    
    public void ChangePricing(int quantity, decimal pricePerUnit)
    {
        Throw.When.True(quantity < 1, "Quantidade deve ser maior que zero.");
        Throw.When.True(pricePerUnit <= 0, "Preço por unidade deve ser maior que zero.");
        
        Quantity = quantity;
        Price = quantity * pricePerUnit;
    }
    
    public void ChangeDescription(string description)
    {
        Description = description;
    }
}