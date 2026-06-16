using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Basket.Application.Commands.Basket;

public class CreateBasketCommand(string userName, List<ShoppingCartItemResponse> shoppingCartItems) 
    : IRequest<ShoppingCartResponse>
{
    public string UserName { get; set; } = userName;
    public List<ShoppingCartItemResponse> Items { get; set; } = shoppingCartItems;  
}

public class CreateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
    : IRequestHandler<CreateBasketCommand, ShoppingCartResponse>
{
    public async Task<ShoppingCartResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = mapper.Map<ShoppingCart>(request);
        var result = await basketRepository.UpdateBasketAsync(shoppingCart);
        return result == null ? new ShoppingCartResponse() : mapper.Map<ShoppingCartResponse>(result);
    }
}
