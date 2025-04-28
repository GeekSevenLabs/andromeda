namespace Andromeda.Application.Shared.RawMaterials.List;

public class ListRawMaterialsRequest : IRequest<ListRawMaterialsResponseItem[]>
{
    public string? Term { get; set; }
}