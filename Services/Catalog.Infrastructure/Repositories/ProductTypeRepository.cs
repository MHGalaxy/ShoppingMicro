using Catalog.Core.Entities;
using Catalog.Core.Repositories;

namespace Catalog.Infrastructure.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    public Task<IEnumerable<ProductType>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
