using Andromeda.Application.RawMaterials;
using Andromeda.Application.Shared.RawMaterials;
using Andromeda.Domain.RawMaterials;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Queries;

internal class RawMaterialQueries(AndromedaDbContext db) : IRawMaterialQueries
{
    public IQueryable<RawMaterial> Queryable() => db.RawMaterials.AsNoTracking().AsQueryable();

    public async Task<RawMaterialDto[]> ListAsync(string? term)
    {
        var query = db.RawMaterials
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(term))
        {
            query = query.Where(rm => rm.Name.Contains(term) || rm.Brand.Contains(term));
        }

        return await query
            .Where(raw => raw.IsDeleted == false)
            .Select(rm => new RawMaterialDto
            {
                Id = rm.Id,
                Name = rm.Name,
                Brand = rm.Brand,
                Description = rm.Description,
                UnitOfMeasure = rm.UnitOfMeasure,
                CostPerUnit = rm.CostPerUnit,
                IsDeleted = rm.IsDeleted
            })
            .ToArrayAsync();
    }

    public Task<RawMaterialDto?> GetAsync(Guid id)
    {
        return db.RawMaterials
            .AsNoTracking()
            .Where(rm => rm.Id == id)
            .Select(rm => new RawMaterialDto
            {
                Id = rm.Id,
                Name = rm.Name,
                Brand = rm.Brand,
                Description = rm.Description,
                UnitOfMeasure = rm.UnitOfMeasure,
                CostPerUnit = rm.CostPerUnit,
                IsDeleted = rm.IsDeleted
            })
            .FirstOrDefaultAsync();
    }
}