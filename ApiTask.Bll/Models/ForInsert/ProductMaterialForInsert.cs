namespace ApiTaskCodeFirst.Bll.Models.ForInsert;

public sealed class ProductMaterialForInsert
{
    public string Name { get; set; }

    public ProductAttributeForInsert? ProductAttribute { get; set; }
}
