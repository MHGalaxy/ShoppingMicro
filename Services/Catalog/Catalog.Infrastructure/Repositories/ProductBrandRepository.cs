using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductBrandRepository(ICatalogContext context) : IProductBrandRepository
{
    public async Task<IEnumerable<ProductBrand>> GetAllAsync() => await context.ProductBrands.Find(x => true).ToListAsync();

}
