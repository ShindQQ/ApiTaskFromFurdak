namespace ApiTaskCodeFirst.Bll.Models.ForInsert;

public sealed class ProductSeasonForInsert
{
    public string Name { get; set; }

    public ProductAttributeForInsert? ProductAttribute { get; set; }
}
