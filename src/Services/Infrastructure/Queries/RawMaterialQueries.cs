using Andromeda.Application.RawMaterials;
using Andromeda.Application.RawMaterials.Get;
using Andromeda.Application.RawMaterials.List;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Andromeda.Domain.RawMaterials;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Queries;

internal class RawMaterialQueries(AndromedaDbContext db) : IRawMaterialQueries
{
    public IQueryable<RawMaterial> Queryable() => db.RawMaterials.AsNoTracking().AsQueryable();

    public async Task<ListRawMaterialsResponseItem[]> ListAsync(string? term)
    {
        var query = db.RawMaterials
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(term))
        {
            query = query.Where(rm => rm.Name.Contains(term) || rm.Brand.Contains(term));
        }

        return await query
            .Where(raw => raw.IsDeleted == false)
            .Select(rm => new ListRawMaterialsResponseItem
            {
                Id = rm.Id,
                Name = rm.Name,
                Brand = rm.Brand,
                Description = rm.Description,
                UnitOfMeasure = rm.UnitOfMeasure,
                CostPerUnit = rm.CostPerUnit
            })
            .ToArrayAsync();
    }

    public Task<GetRawMaterialResponse?> GetAsync(Guid id)
    {
        return db.RawMaterials
            .AsNoTracking()
            .Where(rm => rm.Id == id)
            .Where(raw => raw.IsDeleted == false)
            .Select(rm => new GetRawMaterialResponse
            {
                Id = rm.Id,
                Name = rm.Name,
                Brand = rm.Brand,
                Description = rm.Description,
                UnitOfMeasure = rm.UnitOfMeasure,
                CostPerUnit = rm.CostPerUnit
            })
            .FirstOrDefaultAsync();
    }
}