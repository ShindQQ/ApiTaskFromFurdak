using ApiTask.Bll.Models;
using ApiTask.Dal.Entities;

namespace ApiTask.Bll.Services;

public interface IProductsService
{
    Task<List<Product>> GetAsync();

    Task<Product> FindProductAsync(ProductForSearchDto productForSearch);

    Task<List<Product>> FindProductsAsync(ProductForSearchDto productForSearch);

    Task<Product> AddAsync(Product product);

    Task<Product> ChangeProductQuantityAsync(int id, int quantity);

    Task<Product> ChangeProductAttributesAsync(int id, List<ProductAttribute> productAttributes);

    Task<Product> AddProductAttributesAsync(int id, List<ProductAttribute> productAttributes);

    Task RemoveAsync(int id);
}
