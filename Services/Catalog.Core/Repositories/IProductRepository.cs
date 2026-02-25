using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(string id);
    Task<IEnumerable<Product>> GetProductByNameAsync(string name);
    Task<IEnumerable<Product>> GetProductByTypeAsync(string type);
    Task<IEnumerable<Product>> GetProductByTypeIdAsync(string typeId);
    Task<IEnumerable<Product>> GetProductByBrandAsync(string brand);
    Task<IEnumerable<Product>> GetProductByBrandIdAsync(string brandId);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(Product product);
    Task<bool> DeleteProductAsync(string id);
}
