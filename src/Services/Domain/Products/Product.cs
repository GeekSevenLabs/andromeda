namespace Andromeda.Domain.Products;

public class Product : Entity, IAggregateRoot
{
    private readonly List<ProductComposition> _compositions = [];

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Product() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public Product(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public IReadOnlyList<ProductComposition> Compositions => _compositions.AsReadOnly();
    
    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void ChangeComposition(Guid? compositionId, Guid rawMaterialId, string description, int quantity)
    {
        var composition = _compositions.FirstOrDefault(composition => composition.Id == compositionId);
        
        if (composition is not null)
        {
            composition.ChangeRawMaterial(rawMaterialId);
            composition.ChangeQuantity(quantity);
            composition.ChangeDescription(description);
            return;
        }
        
        _compositions.Add(new ProductComposition(Id, rawMaterialId, description, quantity));
    }
    
    public void RemoveCompositions(Guid[] compositionIds)
    {
        _compositions.RemoveAll(composition => compositionIds.Contains(composition.Id));
    }
    
}