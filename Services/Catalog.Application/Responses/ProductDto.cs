namespace Catalog.Application.Responses;

public class ProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public ProductTypeDto Type { get; set; }
    public ProductBrandDto Brand { get; set; }
}
