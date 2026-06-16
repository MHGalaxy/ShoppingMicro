using Basket.Application.Responses;
using Basket.Core.Repositories;
using MapsterMapper;
using MediatR;

namespace Basket.Application.Queries.Basket;

public class GetBasketByUserNameQuery(string userName) : IRequest<ShoppingCartResponse>
{
    public string UserName { get; set; } = userName;
}

public class GetBasketByUserNameQueryHandler(IBasketRepository basketRepository, IMapper mapper)
    : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
{
    public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasketAsync(request.UserName);
        return basket == null ? new ShoppingCartResponse(request.UserName) : mapper.Map<ShoppingCartResponse>(basket);
    }
}
