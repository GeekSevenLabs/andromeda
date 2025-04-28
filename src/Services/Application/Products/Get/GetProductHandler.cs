using Andromeda.Application.Shared.Products.Get;

namespace Andromeda.Application.Products.Get;

public class GetProductHandler(IProductQueries queries) : IHandler<GetProductRequest, GetProductResponse>
{
    public async Task<GetProductResponse> HandleAsync(GetProductRequest request, CancellationToken cancellationToken = default)
    {
        var product = await queries.GetAsync(request.Id);
        Throw.Http.NotFound.When.Null(product, "Produto não encontrado.");
        return product;
    }
}