using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetProductsByTypeIdQuery : IRequest<IEnumerable<ProductDto>>
{
    public string TypeId { get; set; }
    public GetProductsByTypeIdQuery(string typeId)
    {
        TypeId = typeId;
    }
}

public class GetProductsByTypeIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsByTypeIdQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsByTypeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByTypeIdAsync(request.TypeId);
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }
}
