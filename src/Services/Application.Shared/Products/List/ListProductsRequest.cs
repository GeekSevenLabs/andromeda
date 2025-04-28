namespace Andromeda.Application.Shared.Products.List;

public class ListProductsRequest : IRequest<ListProductsResponseItem[]>
{
    public string? Term { get; set; }
}