using ApiTaskCodeFirst.Dal.Entities;

namespace ApiTask.Bll.Services;

public interface IProductsService
{
    Task<Product> AddProductAsync(Product product);

    Task RemovedProductAsync(Product product);
}
