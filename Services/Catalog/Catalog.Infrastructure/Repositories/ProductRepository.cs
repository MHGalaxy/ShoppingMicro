using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.SpecsParams;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ICatalogContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync(CatalogSpecsParams specsParams)
    {
        return await context.Products.Find(x => true).ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(string id) => await context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name) => await context.Products.Find(x => x.Name == name).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByTypeAsync(string type) => await context.Products.Find(x => x.Type.Name == type).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByTypeIdAsync(string typeId) => await context.Products.Find(x => x.Type.Id == typeId).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string brand) => await context.Products.Find(x => x.Brand.Name == brand).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByBrandIdAsync(string brandId) => await context.Products.Find(x => x.Brand.Id == brandId).ToListAsync();

    public async Task<Product> CreateProductAsync(Product product)
    {
        await context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var result = await context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        var result = await context.Products.DeleteOneAsync(x => x.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<bool> DeleteProductAsync(Product product) => await DeleteProductAsync(product.Id);

}
