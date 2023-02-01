using ApiTask.Bll.Models.Error;
using ApiTaskCodeFirst.Dal.Contexts;
using ApiTaskCodeFirst.Dal.Entities;
using System.Net;

namespace ApiTask.Bll.Services;

public sealed class ProductsService : IProductsService
{
    private readonly ProductsContext _productsContext;

    public ProductsService(ProductsContext productsContext)
    {
        _productsContext = productsContext ?? throw new ArgumentNullException(nameof(productsContext));
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        if (product == null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Product entity cannot be null!");
        }

        await _productsContext.AddAsync(product);
        await _productsContext.SaveChangesAsync();

        return product;
    }

    public async Task RemovedProductAsync(Product product)
    {
        if (product == null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Product entity cannot be null!");
        }

        _productsContext.Remove(product);
        await _productsContext.SaveChangesAsync();
    }
}
