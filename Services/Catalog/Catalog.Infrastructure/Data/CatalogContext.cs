using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<ProductType> ProductTypes { get; }
    public IMongoCollection<ProductBrand> ProductBrands { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        //Get all collections:
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ProductsCollection"));
        ProductTypes = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:BrandsCollection"));
        ProductBrands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:TypesCollection"));

        //Seed data:
        ProductSeedData.SeedData(Products);
        ProductTypeSeedData.SeedData(ProductTypes);
        ProductBrandSeedData.SeedData(ProductBrands);
    }
}
