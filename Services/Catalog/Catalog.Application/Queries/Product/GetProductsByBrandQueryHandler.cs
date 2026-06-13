using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetProductsByBrandQuery : IRequest<IEnumerable<ProductResponse>>
{
    public string BrandName { get; set; }
    public GetProductsByBrandQuery(string brandName)
    {
        BrandName = brandName;
    }
}

public class GetProductsByBrandQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsByBrandQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByBrandAsync(request.BrandName);
        return mapper.Map<IEnumerable<ProductResponse>>(result);
    }
}
