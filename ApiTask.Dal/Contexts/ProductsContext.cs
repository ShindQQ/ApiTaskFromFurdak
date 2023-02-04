using ApiTask.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTask.Dal.Contexts;

public sealed class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().OwnsMany(product => product.ProductAttributes,
            attribute =>
            {
                attribute.WithOwner().HasForeignKey("OwnerId");
                attribute.Property<int>("Id");
                attribute.HasKey("Id");
            });
    }

    public DbSet<Product> Products { get; set; } = null!;
}
