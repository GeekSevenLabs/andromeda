namespace Andromeda.Domain.RawMaterials;

public class RawMaterial : Entity, IAggregateRoot
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private RawMaterial() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public RawMaterial(string name, string brand, string description, UnitOfMeasureType unitOfMeasure, decimal costPerUnit)
    {
        Name = name;
        Brand = brand;
        Description = description;
        UnitOfMeasure = unitOfMeasure;
        CostPerUnit = costPerUnit;
    }
    
    public string Name { get; private set; }
    public string Brand { get; private set; }
    public string Description { get; private set; }

    public UnitOfMeasureType UnitOfMeasure { get; private set; }
    public decimal CostPerUnit { get; private set; }
    
    public void Update(string name, string brand, string description, UnitOfMeasureType unitOfMeasure, decimal costPerUnit)
    {
        Name = name;
        Brand = brand;
        Description = description;
        UnitOfMeasure = unitOfMeasure;
        CostPerUnit = costPerUnit;
    }
}