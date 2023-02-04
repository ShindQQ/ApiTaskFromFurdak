using Microsoft.EntityFrameworkCore;

namespace ApiTask.Dal.Entities;

[Owned]
public sealed class ProductAttribute
{
    public string Name { get; set; }
}
