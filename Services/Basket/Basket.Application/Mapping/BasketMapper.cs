using Basket.Application.Commands.Basket;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Mapster;

namespace Basket.Application.Mapping;

public class BasketMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ShoppingCart, ShoppingCartResponse>();
        config.NewConfig<ShoppingCartResponse, ShoppingCart>();

        config.NewConfig<ShoppingCartItem, ShoppingCartItemResponse>();
        config.NewConfig<ShoppingCartItemResponse, ShoppingCartItem>();

        config.NewConfig<CreateBasketCommand, ShoppingCart>();
        config.NewConfig<ShoppingCart, CreateBasketCommand>();
    }
}
