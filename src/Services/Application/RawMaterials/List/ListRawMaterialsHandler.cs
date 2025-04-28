using Andromeda.Application.Shared.RawMaterials.List;

namespace Andromeda.Application.RawMaterials.List;

public class ListRawMaterialsHandler(IRawMaterialQueries queries) : IHandler<ListRawMaterialsRequest, ListRawMaterialsResponseItem[]>
{
    public async Task<ListRawMaterialsResponseItem[]> HandleAsync(ListRawMaterialsRequest request, CancellationToken cancellationToken = default)
    {
        return await queries.ListAsync(request.Term);
    }
}