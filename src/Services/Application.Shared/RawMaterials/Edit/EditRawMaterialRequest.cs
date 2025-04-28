using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Domain.Shared;

namespace Andromeda.Application.Shared.RawMaterials.Edit;

public class EditRawMaterialRequest : IRequest
{
    public Guid? Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public UnitOfMeasureType? UnitOfMeasure { get; set; }
    public decimal? CostPerUnit { get; set; }

    public void CopyFrom(GetRawMaterialResponse rawMaterial)
    {
        Id = rawMaterial.Id;
        Name = rawMaterial.Name;
        Brand = rawMaterial.Brand;
        Description = rawMaterial.Description;
        UnitOfMeasure = rawMaterial.UnitOfMeasure;
        CostPerUnit = rawMaterial.CostPerUnit;
    }
}