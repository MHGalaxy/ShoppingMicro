using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetProductsByNameQuery : IRequest<IEnumerable<ProductDto>>
{
    public string Name { get; set; }
    public GetProductsByNameQuery(string name)
    {
        Name = name;
    }
}

public class GetProductsByNameQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsByNameQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductsByNameAsync(request.Name);
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }
}
