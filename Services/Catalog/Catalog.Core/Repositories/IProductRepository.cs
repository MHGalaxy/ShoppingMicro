using Catalog.Core.Entities;
using Catalog.Core.SpecsParams;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync(CatalogSpecsParams specsParams);
    Task<Product> GetProductByIdAsync(string id);
    Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    Task<IEnumerable<Product>> GetProductsByTypeAsync(string type);
    Task<IEnumerable<Product>> GetProductsByTypeIdAsync(string typeId);
    Task<IEnumerable<Product>> GetProductsByBrandAsync(string brand);
    Task<IEnumerable<Product>> GetProductsByBrandIdAsync(string brandId);
    Task<Product> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(Product product);
    Task<bool> DeleteProductAsync(string id);
}
