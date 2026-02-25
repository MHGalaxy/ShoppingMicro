using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data;

public static class ProductTypeSeedData
{
    public static void SeedData(IMongoCollection<ProductType> collection)
    {
        var existCollection = collection.Find(x => true).Any();
        if (existCollection) return;

        var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "brands.json");

        if (!File.Exists(pathJson))
        {
            throw new Exception($"The seed data file of types.json not found at : {pathJson}");
        }

        var dataText = File.ReadAllText(pathJson);
        var productTypes = JsonSerializer.Deserialize<List<ProductType>>(dataText);

        if (productTypes != null)
            collection.InsertMany(productTypes);
    }
}
