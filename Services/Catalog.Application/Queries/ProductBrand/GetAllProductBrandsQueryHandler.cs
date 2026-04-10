using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.ProductBrand;

public class GetAllProductBrandsQuery : IRequest<IEnumerable<ProductBrandDto>>
{
    //Filters
}

public class GetAllProductBrandsQueryHandler(IProductBrandRepository productBrandRepository, IMapper mapper)
    : IRequestHandler<GetAllProductBrandsQuery, IEnumerable<ProductBrandDto>>
{
    public async Task<IEnumerable<ProductBrandDto>> Handle(GetAllProductBrandsQuery request, CancellationToken cancellationToken)
    {
        var result = await productBrandRepository.GetAllAsync();
        return mapper.Map<IEnumerable<ProductBrandDto>>(result);
    }
}