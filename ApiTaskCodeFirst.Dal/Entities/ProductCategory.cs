namespace ApiTaskCodeFirst.Dal.Entities;

public sealed class ProductCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Product> Products { get; set; } = new();
}
