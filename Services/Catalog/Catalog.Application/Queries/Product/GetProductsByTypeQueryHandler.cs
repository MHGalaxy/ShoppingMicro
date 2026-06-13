using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetProductsByTypeQuery : IRequest<IEnumerable<ProductResponse>>
{
    public string TypeName { get; set; }
    public GetProductsByTypeQuery(string typeName)
    {
        TypeName = typeName;
    }
}

public class GetProductsByTypeQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsByTypeQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetProductsByTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByTypeAsync(request.TypeName);
        return mapper.Map<IEnumerable<ProductResponse>>(result);
    }
}
