using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository(IDistributedCache redis) : IBasketRepository
{
    public async Task<ShoppingCart?> GetBasketAsync(string userName)
    {
        var basket = await redis.GetStringAsync(userName);
        return string.IsNullOrEmpty(basket) ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart shoppingCart)
    {
        await redis.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
        return await GetBasketAsync(shoppingCart.UserName);
    }

    public async Task<bool> DeleteBasketAsync(string userName)
    {
        await redis.RemoveAsync(userName);
        return true;
    }
}
