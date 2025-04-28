using Andromeda.Domain.Shared;

namespace Andromeda.Application.Shared.RawMaterials.List;

public class ListRawMaterialsResponseItem
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Brand { get; init; }
    public required string Description { get; init; }
    public required UnitOfMeasureType UnitOfMeasure { get; init; }
    public required decimal CostPerUnit { get; init; }
}