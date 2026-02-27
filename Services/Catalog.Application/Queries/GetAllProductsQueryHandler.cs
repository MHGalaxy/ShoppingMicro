using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{
    //Filters
}

public class GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetAllProductsAsync();
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }
}
