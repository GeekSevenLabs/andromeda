using Andromeda.Application.Shared.Products.Get;

namespace Andromeda.Application.Shared.Products.Edit;

public class EditProductRequest : IRequest
{
    public Guid? Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<ProductCompositionModel> Compositions { get; set; } = [];

    public void CopyFrom(GetProductResponse product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Compositions = product.Compositions.ToList();
    }
}