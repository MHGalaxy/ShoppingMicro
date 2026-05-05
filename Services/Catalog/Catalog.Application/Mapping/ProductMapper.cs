using Catalog.Application.Commands.Product;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.SpecsParams;
using Mapster;

namespace Catalog.Application.Mapping;

public class ProductMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductDto>();
        config.NewConfig<ProductDto, Product>();

        config.NewConfig<Pagination<Product>, Pagination<ProductDto>>();
        config.NewConfig<Pagination<ProductDto>, Pagination<Product>>();

        config.NewConfig<ProductBrand, ProductBrandDto>();
        config.NewConfig<ProductBrandDto, ProductBrand>();

        config.NewConfig<ProductType, ProductTypeDto>();
        config.NewConfig<ProductTypeDto, ProductType>();

        config.NewConfig<CreateProductCommand, Product>();
        config.NewConfig<Product, CreateProductCommand>();

        config.NewConfig<UpdateProductCommand, Product>();
        config.NewConfig<Product, UpdateProductCommand>();
    }
}
