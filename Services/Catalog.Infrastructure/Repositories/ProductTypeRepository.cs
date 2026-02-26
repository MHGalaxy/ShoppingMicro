using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductTypeRepository(ICatalogContext context) : IProductTypeRepository
{
    public async Task<IEnumerable<ProductType>> GetAllAsync() => await context.ProductTypes.Find(x => true).ToListAsync();
}
