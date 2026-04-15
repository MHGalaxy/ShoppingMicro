using Catalog.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Queries.Product;

public class DeleteProductCommand : IRequest<bool>
{
    public string Id { get; set; }
}

public class DeleteProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await productRepository.DeleteProductAsync(request.Id);
    }
}