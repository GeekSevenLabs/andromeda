namespace Andromeda.Application.Shared.RawMaterials.List;

public class ListRawMaterialsRequest : IRequest<RawMaterialDto[]>
{
    public string? Term { get; set; }
}