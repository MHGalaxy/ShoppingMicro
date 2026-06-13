using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.ProductBrand;

public class GetAllProductBrandsQuery : IRequest<IEnumerable<ProductBrandResponse>>
{
    //Filters
}

public class GetAllProductBrandsQueryHandler(IProductBrandRepository productBrandRepository, IMapper mapper)
    : IRequestHandler<GetAllProductBrandsQuery, IEnumerable<ProductBrandResponse>>
{
    public async Task<IEnumerable<ProductBrandResponse>> Handle(GetAllProductBrandsQuery request, CancellationToken cancellationToken)
    {
        var result = await productBrandRepository.GetAllAsync();
        return mapper.Map<IEnumerable<ProductBrandResponse>>(result);
    }
}