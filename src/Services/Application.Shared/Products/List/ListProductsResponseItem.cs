namespace Andromeda.Application.Shared.Products.List;

public class ListProductsResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int CompositionsCount { get; set; }
}