using ApiTaskCodeFirst.Dal.Entities;

namespace ApiTask.Bll.Models;

public sealed class ProductForInsertAndUpdateDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; }

    public List<ProductAttribute> ProductAttributes { get; set; } = new();
}
