using Andromeda.Application.Shared.Products.List;

namespace Andromeda.Application.Products.List;

public class ListProductsHandler(IProductQueries queries) : IHandler<ListProductsRequest, ListProductsResponseItem[]>
{
    public async Task<ListProductsResponseItem[]> HandleAsync(ListProductsRequest request, CancellationToken cancellationToken = default)
    {
        return await queries.ListAsync(request.Term);
    }
}