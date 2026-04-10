using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public string Id { get; set; }
    public GetProductByIdQuery(string id)
    {
        Id = id;
    }
}

public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductByIdAsync(request.Id);
        if (result == null) throw new Exception($"The product id: {request.Id} is not found");

        return mapper.Map<ProductDto>(result);
    }
}