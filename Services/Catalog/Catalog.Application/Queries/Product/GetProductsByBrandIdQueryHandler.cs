using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetProductsByBrandIdQuery : IRequest<IEnumerable<ProductResponse>>
{
    public string BrandId { get; set; }
    public GetProductsByBrandIdQuery(string brandId)
    {
        BrandId = brandId;
    }
}

public class GetProductsByBrandIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsByBrandIdQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetProductsByBrandIdQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByBrandIdAsync(request.BrandId);
        return mapper.Map<IEnumerable<ProductResponse>>(result);
    }
}
