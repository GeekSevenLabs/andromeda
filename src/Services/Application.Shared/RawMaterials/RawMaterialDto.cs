using Andromeda.Domain.Shared;

namespace Andromeda.Application.Shared.RawMaterials;

public class RawMaterialDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Brand { get; init; }
    public required string Description { get; init; }
    public required UnitOfMeasureType UnitOfMeasure { get; init; }
    public required decimal CostPerUnit { get; init; }
    public required bool IsDeleted { get; init; }

    public override string ToString()
    {
        return $"{Name} - {Brand} - {CostPerUnit.ToCurrency()} por {UnitOfMeasure.ToEnumOption().ShortName}";
    }
}