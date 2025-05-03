namespace Andromeda.Application.Shared.RawMaterials.Get;

public class GetRawMaterialRequest : IRequest<RawMaterialDto>
{
    public required Guid Id { get; init; }
}