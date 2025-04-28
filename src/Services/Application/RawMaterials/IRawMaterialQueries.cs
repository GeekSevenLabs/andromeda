using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Andromeda.Domain.RawMaterials;

namespace Andromeda.Application.RawMaterials;

public interface IRawMaterialQueries
{
    IQueryable<RawMaterial> Queryable();
    
    Task<ListRawMaterialsResponseItem[]> ListAsync(string? term);
    Task<GetRawMaterialResponse?> GetAsync(Guid id);
}