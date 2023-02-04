using ApiTask.Bll.Models;
using ApiTask.Bll.Models.Error;
using ApiTask.Dal.Contexts;
using ApiTask.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiTask.Bll.Services;

public sealed class ProductsService : IProductsService
{
    private readonly ProductsContext _productsContext;

    public ProductsService(ProductsContext productsContext)
    {
        _productsContext = productsContext ?? throw new ArgumentNullException(nameof(productsContext));
    }

    public async Task<List<Product>> GetAsync()
    {
        return await _productsContext.Products.ToListAsync();
    }

    private IQueryable<Product> FindProducts(ProductForSearchDto productForSearch)
    {
        if (productForSearch == null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"{nameof(productForSearch)} searching parameters cannot be empty!");
        }

        var products = _productsContext.Products
            .Where(product => !productForSearch.Id.HasValue || product.Id == productForSearch.Id)
            .Where(product => string.IsNullOrEmpty(productForSearch.Category) ||
                product.Category.ToLower().Equals(productForSearch.Category.ToLower()));

        if (!products.Any())
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"{nameof(products)} entity does not found!");
        }

        return products;
    }

    public async Task<Product> FindProductAsync(ProductForSearchDto productForSearch)
    {
        return await FindProducts(productForSearch).FirstAsync();
    }

    public async Task<List<Product>> FindProductsAsync(ProductForSearchDto productForSearch)
    {
        return await FindProducts(productForSearch).ToListAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        if (product == null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"{nameof(product)} entity cannot be null!");
        }

        await _productsContext.AddAsync(product);
        await _productsContext.SaveChangesAsync();

        return product;
    }

    public async Task RemoveAsync(int id)
    {
        _productsContext.Remove(new Product { Id = id });
        await _productsContext.SaveChangesAsync();
    }

    public async Task<Product> ChangeProductQuantityAsync(int id, int quantity)
    {
        if (quantity < 0)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Quantity cannot be less than zero!");
        }

        var product = await FindProductAsync(new ProductForSearchDto { Id = id });

        product.Quantity = quantity;

        return await UpdateAsync(product);
    }

    public async Task<Product> ChangeProductAttributesAsync(int id, List<ProductAttribute> productAttributes)
    {
        if (productAttributes == null || productAttributes.Count == 0)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"{nameof(productAttributes)} cannot be null or empty!");
        }

        var product = await FindProductAsync(new ProductForSearchDto { Id = id });

        product.ProductAttributes = productAttributes;

        return await UpdateAsync(product);
    }

    public async Task<Product> AddProductAttributesAsync(int id, List<ProductAttribute> productAttributes)
    {
        if (productAttributes == null || productAttributes.Count == 0)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"{nameof(productAttributes)} cannot be null or empty!");
        }

        var product = await FindProductAsync(new ProductForSearchDto { Id = id });

        product.ProductAttributes.AddRange(productAttributes);

        return await UpdateAsync(product);
    }

    private async Task<Product> UpdateAsync(Product product)
    {
        _productsContext.Products.Update(product);
        await _productsContext.SaveChangesAsync();

        return product;
    }
}
