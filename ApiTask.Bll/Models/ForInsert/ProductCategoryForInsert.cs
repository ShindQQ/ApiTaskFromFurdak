namespace ApiTaskCodeFirst.Bll.Models.ForInsert;

public sealed class ProductCategoryForInsert
{
    public string Name { get; set; }

    public List<ProductForInsert> Products { get; set; } = new();
}
