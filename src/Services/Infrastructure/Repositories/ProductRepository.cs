using Andromeda.Domain.Products;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Repositories;

internal class ProductRepository(AndromedaDbContext db) : BaseRepository<Product, Guid>(db), IProductRepository;