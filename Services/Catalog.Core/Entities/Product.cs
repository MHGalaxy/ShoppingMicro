using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.Core.Entities;

public class Product: BaseEntity
{
    [BsonElement(nameof(Name))]
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }

    //Relations
    public ProductType Type { get; set; } 
    public ProductBrand Brand { get; set; }
}
