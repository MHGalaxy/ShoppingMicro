using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Mapster;

namespace Catalog.Application.Mapping;

public class ProductMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductDto>();
        config.NewConfig<ProductDto, Product>();

        config.NewConfig<ProductBrand, ProductBrandDto>();
        config.NewConfig<ProductBrandDto, ProductBrand>();

        config.NewConfig<ProductType, ProductTypeDto>();
        config.NewConfig<ProductTypeDto, ProductType>();
    }
}
