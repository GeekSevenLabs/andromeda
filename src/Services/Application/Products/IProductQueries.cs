using Andromeda.Application.Shared.Products.Get;
using Andromeda.Application.Shared.Products.List;

namespace Andromeda.Application.Products;

public interface IProductQueries
{
    Task<ListProductsResponseItem[]> ListAsync(string? term);

    Task<GetProductResponse?> GetAsync(Guid productId);
}