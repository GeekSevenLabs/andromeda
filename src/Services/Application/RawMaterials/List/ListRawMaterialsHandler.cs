using Andromeda.Application.Shared.RawMaterials;
using Andromeda.Application.Shared.RawMaterials.List;

namespace Andromeda.Application.RawMaterials.List;

public class ListRawMaterialsHandler(IRawMaterialQueries queries) : IHandler<ListRawMaterialsRequest, RawMaterialDto[]>
{
    public async Task<RawMaterialDto[]> HandleAsync(ListRawMaterialsRequest request, CancellationToken cancellationToken = default)
    {
        return await queries.ListAsync(request.Term);
    }
}