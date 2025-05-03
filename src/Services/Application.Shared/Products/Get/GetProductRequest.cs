namespace Andromeda.Application.Shared.Products.Get;

public class GetProductRequest : IRequest<GetProductResponse>
{
    public required Guid Id { get; init; }
}