using ApiTaskCodeFirst.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTaskCodeFirst.Dal.Contexts;

public sealed class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductAttribute>().HasMany(productAttribute => productAttribute.Sizes)
            .WithOne(productSize => productSize.ProductAttribute);
        modelBuilder.Entity<ProductAttribute>().HasMany(productAttribute => productAttribute.Materials)
            .WithOne(productMaterial => productMaterial.ProductAttribute);
        modelBuilder.Entity<ProductAttribute>().HasMany(productAttribute => productAttribute.Seasons)
            .WithOne(productSeason => productSeason.ProductAttribute);
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductAttribute> ProductAttributes { get; set; } = null!;

    public DbSet<ProductSize> ProductSizes { get; set; } = null!;

    public DbSet<ProductSeason> ProductSeasons { get; set; } = null!;

    public DbSet<ProductMaterial> ProductMaterials { get; set; } = null!;

    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
}
