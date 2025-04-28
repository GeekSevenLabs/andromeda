using Andromeda.Application.Shared.RawMaterials.Edit;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Andromeda.Application.Shared.RawMaterials.Remove;

namespace Andromeda.Application.Shared.RawMaterials;

public class RawMaterialViewService(IEndpointService endpointService) : IRawMaterialViewService
{
    public async Task EditAsync(EditRawMaterialRequest request)
    {
        await endpointService.PostAsync(AndromedaHandlerDefinitions.RawMaterials.EditRawMaterial, request);
    }

    public async Task<GetRawMaterialResponse> GetAsync(GetRawMaterialRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.RawMaterials.GetRawMaterial, request);
    }

    public async Task<ListRawMaterialsResponseItem[]> ListAsync(ListRawMaterialsRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.RawMaterials.ListRawMaterials, request);
    }
    
    public async Task RemoveAsync(RemoveRawMaterialRequest request)
    {
        await endpointService.PostAsync(AndromedaHandlerDefinitions.RawMaterials.RemoveRawMaterial, request);
    }
}