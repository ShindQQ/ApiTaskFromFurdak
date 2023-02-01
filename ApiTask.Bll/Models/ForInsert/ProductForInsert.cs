namespace ApiTaskCodeFirst.Bll.Models.ForInsert;

public sealed class ProductForInsert
{
    public string Name { get; set; }

    public string Description { get; set; }

    public ProductAttributeForInsert? Attribute { get; set; }

    public List<ProductCategoryForInsert> ProductCategories { get; set; } = new();
}
