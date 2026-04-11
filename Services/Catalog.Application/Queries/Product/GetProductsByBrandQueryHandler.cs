using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetProductsByBrandQuery : IRequest<IEnumerable<ProductDto>>
{
    public string BrandName { get; set; }
    public GetProductsByBrandQuery(string brandName)
    {
        BrandName = brandName;
    }
}

public class GetProductsByBrandQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsByBrandQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByBrandAsync(request.BrandName);
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }
}
