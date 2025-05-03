using Andromeda.Application.Shared.RawMaterials;
using Andromeda.Domain.RawMaterials;

namespace Andromeda.Application.RawMaterials;

public interface IRawMaterialQueries
{
    IQueryable<RawMaterial> Queryable();
    
    Task<RawMaterialDto[]> ListAsync(string? term);
    Task<RawMaterialDto?> GetAsync(Guid id);
}