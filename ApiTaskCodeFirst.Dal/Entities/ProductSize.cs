namespace ApiTaskCodeFirst.Dal.Entities;

public sealed class ProductSize
{
    public Guid Id { get; set; }

    public int Size { get; set; }

    public ProductAttribute? ProductAttribute { get; set; }
}
