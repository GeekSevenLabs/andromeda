namespace Andromeda.Domain.RawMaterials;

public interface IRawMaterialRepository
{
    void Add(RawMaterial rawMaterial);
    Task<RawMaterial?> GetAsync(Guid id);
}