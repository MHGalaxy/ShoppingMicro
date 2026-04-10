using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.ProductType;

public class GetAllProductTypesQuery : IRequest<IEnumerable<ProductTypeDto>>
{
}

public class GetAllProductTypesQueryHandler(IProductTypeRepository productTypeRepository, IMapper mapper)
    : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductTypeDto>>
{
    public async Task<IEnumerable<ProductTypeDto>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var result = await productTypeRepository.GetAllAsync();
        return mapper.Map<IEnumerable<ProductTypeDto>>(result);
    }
}
