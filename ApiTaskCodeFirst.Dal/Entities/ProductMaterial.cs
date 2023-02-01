namespace ApiTaskCodeFirst.Dal.Entities;

public sealed class ProductMaterial
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ProductAttribute? ProductAttribute { get; set; }
}
