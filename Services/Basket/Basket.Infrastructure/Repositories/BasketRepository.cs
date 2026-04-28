using Basket.Core.Entities;
using Basket.Core.Repositories;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart shoppingCart)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteBasketAsync(string userName)
    {
        throw new NotImplementedException();
    }
}
