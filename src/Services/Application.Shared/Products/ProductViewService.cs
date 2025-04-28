using Andromeda.Application.Shared.Products.Edit;
using Andromeda.Application.Shared.Products.Get;
using Andromeda.Application.Shared.Products.List;

namespace Andromeda.Application.Shared.Products;

public class ProductViewService(IEndpointService endpointService) : IProductViewService 
{
    public async Task EditAsync(EditProductRequest request)
    {
        await endpointService.PostAsync(AndromedaHandlerDefinitions.Products.EditProduct, request);
    }

    public async Task<GetProductResponse> GetAsync(GetProductRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.Products.GetProduct, request);
    }

    public async Task<ListProductsResponseItem[]> ListAsync(ListProductsRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.Products.ListProducts, request);
    }
}