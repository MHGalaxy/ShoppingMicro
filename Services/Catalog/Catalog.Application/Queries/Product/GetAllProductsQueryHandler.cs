using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.SpecsParams;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetAllProductsQuery : ProductSpecsParams, IRequest<Pagination<ProductResponse>>
{
    //Filters
}

public class GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
{
    public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetAllProductsAsync(request);
        return mapper.Map<Pagination<ProductResponse>>(result);
    }
}
