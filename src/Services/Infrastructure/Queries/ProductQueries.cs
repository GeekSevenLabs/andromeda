using Andromeda.Application.Products;
using Andromeda.Application.Shared.Products;
using Andromeda.Application.Shared.Products.Get;
using Andromeda.Application.Shared.Products.List;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Queries;

internal class ProductQueries(AndromedaDbContext db) : IProductQueries
{
    public async Task<ListProductsResponseItem[]> ListAsync(string? term)
    {
        var query = db.Products
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(term))
        {
            query = query.Where(product => product.Name.Contains(term));
        }

        return await query
            .Where(product => product.IsDeleted == false)
            .Select(p => new ListProductsResponseItem
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CompositionsCount = p.Compositions.Count
            })
            .ToArrayAsync();
    }

    public Task<GetProductResponse?> GetAsync(Guid productId)
    {
        return db.Products
            .AsNoTracking()
            .Where(p => p.Id == productId)
            .Select(p => new GetProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Compositions = p.Compositions.Select(c => new ProductCompositionModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    Quantity = c.Quantity,
                    RawMaterialId = c.RawMaterialId,
                    RawMaterialIsDeleted = c.RawMaterial.IsDeleted
                }).ToArray()
            })
            .FirstOrDefaultAsync();
    }
}