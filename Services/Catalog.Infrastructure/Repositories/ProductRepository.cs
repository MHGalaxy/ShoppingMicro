using Catalog.Core.Entities;
using Catalog.Core.Repositories;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<bool> DeleteProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByBrandAsync(string brand)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByBrandIdAsync(string brandId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByTypeAsync(string type)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByTypeIdAsync(string typeId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
