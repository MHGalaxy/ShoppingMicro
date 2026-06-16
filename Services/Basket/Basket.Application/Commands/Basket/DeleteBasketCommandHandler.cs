using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Commands.Basket;

public class DeleteBasketCommand(string userName) : IRequest<bool>
{
    public string UserName { get; set; } = userName;
}

public class DeleteBasketCommandHandler(IBasketRepository basketRepository)
    : IRequestHandler<DeleteBasketCommand, bool>
{
    public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        return await basketRepository.DeleteBasketAsync(request.UserName);
    }
}
