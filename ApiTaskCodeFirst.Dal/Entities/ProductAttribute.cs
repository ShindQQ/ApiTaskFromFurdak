using Microsoft.EntityFrameworkCore;

namespace ApiTaskCodeFirst.Dal.Entities;

[Owned]
public sealed class ProductAttribute
{
    public string Name { get; set; }
}
