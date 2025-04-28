using Andromeda.Domain;
using Andromeda.Domain.Customers;
using Andromeda.Domain.Products;
using Andromeda.Domain.Quotations;
using Andromeda.Domain.RawMaterials;
using Andromeda.Infrastructure.Configurations;

namespace Andromeda.Infrastructure.Contexts;

internal class AndromedaDbContext(DbContextOptions<AndromedaDbContext> options) : DbContext(options), IAndromedaUnitOfWork
{
    public required DbSet<Customer> Customers { get; init; }
    public required DbSet<Product> Products { get; init; }
    public required DbSet<ProductComposition> ProductCompositions { get; init; }
    public required DbSet<RawMaterial> RawMaterials { get; init; }
    public required DbSet<Quotation> Quotations { get; init; }
    public required DbSet<QuotationItem> QuotationItems { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCompositionConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new RawMaterialConfiguration());
        modelBuilder.ApplyConfiguration(new QuotationConfiguration());
        modelBuilder.ApplyConfiguration(new QuotationItemConfiguration());
    }

    public new Task SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);
}