using Catalog.Core.SpecsParams.Common;

namespace Catalog.Core.SpecsParams;

public class ProductSpecsParams : CommonSpecsParams
{
    public string BrandId { get; set; }
    public string BrandName { get; set; }
    public string TypeId { get; set; }
    public string TypeName { get; set; }
}
