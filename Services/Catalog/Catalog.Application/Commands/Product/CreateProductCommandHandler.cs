using MediatR;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Entities;
using MapsterMapper;

namespace Catalog.Application.Commands.Product;

public class CreateProductCommand : IRequest<ProductResponse>
{
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public ProductTypeResponse Type { get; set; }
    public ProductBrandResponse Brand { get; set; }
}

public class CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<CreateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Core.Entities.Product>(request);
        var result = await productRepository.CreateProductAsync(entity);
        //TODO exception handling
        return mapper.Map<ProductResponse>(result);
    }
}