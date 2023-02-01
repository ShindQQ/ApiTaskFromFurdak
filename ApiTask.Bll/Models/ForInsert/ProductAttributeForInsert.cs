namespace ApiTaskCodeFirst.Bll.Models.ForInsert;

public sealed class ProductAttributeForInsert
{
    public Guid ProductId { get; set; }

    public ProductForInsert? Product { get; set; }

    public List<ProductSeasonForInsert> Seasons { get; set; } = new();

    public List<ProductSizeForInsert> Sizes { get; set; } = new();

    public List<ProductMaterialForInsert> Materials { get; set; } = new();

    public string? Color { get; set; }

    public double? Weight { get; set; }

    public int? Amount { get; set; }

    public string? CountryOfManufacturer { get; set; }

    public int? GuaranteeInMonths { get; set; }

    public string? Design { get; set; }
}
