using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Mapster;

namespace Catalog.Application.Mapping;

public class ProductMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Entity -> DTO
        config.NewConfig<Product, ProductDto>();

        config.NewConfig<ProductDto, Product>();
    }
}
