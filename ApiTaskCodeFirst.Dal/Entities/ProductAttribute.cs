namespace ApiTaskCodeFirst.Dal.Entities;

public sealed class ProductAttribute
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Product? Product { get; set; }

    public List<ProductSeason> Seasons { get; set; } = new();

    public List<ProductSize> Sizes { get; set; } = new();

    public List<ProductMaterial> Materials { get; set; } = new();

    public string? Color { get; set; }

    public double? Weight { get; set; }

    public int? Amount { get; set; }

    public string? CountryOfManufacturer { get; set; }

    public int? GuaranteeInMonths { get; set; }

    public string? Design { get; set; }
}
