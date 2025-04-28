using Andromeda.Application.Shared.Products.Edit;
using Andromeda.Application.Shared.Products.Get;
using Andromeda.Application.Shared.Products.List;

namespace Andromeda.Application.Shared.Products;

public interface IProductViewService
{
    Task EditAsync(EditProductRequest request);
    Task<GetProductResponse> GetAsync(GetProductRequest request);
    Task<ListProductsResponseItem[]> ListAsync(ListProductsRequest request);
}