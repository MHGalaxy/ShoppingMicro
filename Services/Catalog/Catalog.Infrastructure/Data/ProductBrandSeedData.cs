using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data;

public static class ProductBrandSeedData
{
    public static void SeedData(IMongoCollection<ProductBrand> collection)
    {
        var existCollection = collection.Find(x => true).Any();
        if (existCollection) return;

        var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "brands.json");

        if (!File.Exists(pathJson))
        {
            throw new Exception($"The seed data file of brands.json not found at : {pathJson}");
        }

        var dataText = File.ReadAllText(pathJson);
        var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(dataText);

        if (productBrands != null)
            collection.InsertMany(productBrands);
    }
}
