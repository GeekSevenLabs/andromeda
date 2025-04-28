using Andromeda.Application.Shared.RawMaterials.Get;

namespace Andromeda.Application.RawMaterials.Get;

public class GetRawMaterialHandler(IRawMaterialQueries queries) : IHandler<GetRawMaterialRequest, GetRawMaterialResponse>
{
    public async Task<GetRawMaterialResponse> HandleAsync(GetRawMaterialRequest request, CancellationToken cancellationToken = default)
    {
        var response = await queries.GetAsync(request.Id);
        Throw.Http.NotFound.When.Null(response, "Matéria prima não encontrada.");
        return response;
    }
}