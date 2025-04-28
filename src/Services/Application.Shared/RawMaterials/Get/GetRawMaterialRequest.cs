namespace Andromeda.Application.Shared.RawMaterials.Get;

public class GetRawMaterialRequest : IRequest<GetRawMaterialResponse>
{
    public required Guid Id { get; init; }
}