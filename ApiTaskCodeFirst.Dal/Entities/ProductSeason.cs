namespace ApiTaskCodeFirst.Dal.Entities;

public sealed class ProductSeason
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ProductAttribute? ProductAttribute { get; set; }
}
