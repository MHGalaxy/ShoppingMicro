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
        config.NewConfig<Product, ProductResponse>();
        config.NewConfig<ProductResponse, Product>();

        config.NewConfig<Pagination<Product>, Pagination<ProductResponse>>();
        config.NewConfig<Pagination<ProductResponse>, Pagination<Product>>();

        config.NewConfig<ProductBrand, ProductBrandResponse>();
        config.NewConfig<ProductBrandResponse, ProductBrand>();

        config.NewConfig<ProductType, ProductTypeResponse>();
        config.NewConfig<ProductTypeResponse, ProductType>();

        config.NewConfig<CreateProductCommand, Product>();
        config.NewConfig<Product, CreateProductCommand>();

        config.NewConfig<UpdateProductCommand, Product>();
        config.NewConfig<Product, UpdateProductCommand>();
    }
}
