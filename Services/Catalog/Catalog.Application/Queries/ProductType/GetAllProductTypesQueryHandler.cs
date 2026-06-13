using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.ProductType;

public class GetAllProductTypesQuery : IRequest<IEnumerable<ProductTypeResponse>>
{
}

public class GetAllProductTypesQueryHandler(IProductTypeRepository productTypeRepository, IMapper mapper)
    : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductTypeResponse>>
{
    public async Task<IEnumerable<ProductTypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var result = await productTypeRepository.GetAllAsync();
        return mapper.Map<IEnumerable<ProductTypeResponse>>(result);
    }
}
