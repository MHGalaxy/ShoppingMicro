using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data;

public static class ProductSeedData
{
    public static void SeedData(IMongoCollection<Product> collection)
    {
        var existCollection = collection.Find(x => true).Any();
        if (existCollection) return;

        var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "products.json");

        if (!File.Exists(pathJson))
        {
            throw new Exception($"The seed data file of products.json not found at : {pathJson}");
        }

        var dataText = File.ReadAllText(pathJson);
        var products = JsonSerializer.Deserialize<List<Product>>(dataText);

        if (products != null)
            collection.InsertMany(products);
    }
}
