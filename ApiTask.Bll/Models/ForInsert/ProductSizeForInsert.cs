namespace ApiTaskCodeFirst.Bll.Models.ForInsert;

public sealed class ProductSizeForInsert
{
    public int Size { get; set; }

    public ProductAttributeForInsert? ProductAttribute { get; set; }
}
