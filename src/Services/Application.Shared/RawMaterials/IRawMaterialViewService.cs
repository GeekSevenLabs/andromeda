using Andromeda.Application.Shared.RawMaterials.Edit;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Andromeda.Application.Shared.RawMaterials.Remove;

namespace Andromeda.Application.Shared.RawMaterials;

public interface IRawMaterialViewService
{
    Task EditAsync(EditRawMaterialRequest request);
    Task<GetRawMaterialResponse> GetAsync(GetRawMaterialRequest request);
    Task<ListRawMaterialsResponseItem[]> ListAsync(ListRawMaterialsRequest request);
    Task RemoveAsync(RemoveRawMaterialRequest request);
}