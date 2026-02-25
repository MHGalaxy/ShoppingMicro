using Catalog.Core.Entities;
using Catalog.Core.Repositories;

namespace Catalog.Infrastructure.Repositories;

public class ProductBrandRepository : IProductBrandRepository
{
    public Task<IEnumerable<ProductBrand>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
