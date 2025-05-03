namespace Andromeda.Domain.Products;

public interface IProductRepository
{
    void Add(Product product);
    void Remove(Product product);
    Task<Product?> GetAsync(Guid id);
}