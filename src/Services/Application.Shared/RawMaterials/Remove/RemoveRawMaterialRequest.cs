namespace Andromeda.Application.Shared.RawMaterials.Remove;

public class RemoveRawMaterialRequest : IRequest
{
    public required Guid Id { get; init; }
}