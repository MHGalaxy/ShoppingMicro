using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository(IDistributedCache redis) : IBasketRepository
{
    private static string GetBasketKey(string userName) => $"basket:{userName}";

    public async Task<ShoppingCart?> GetBasketAsync(string userName)
    {
        var basket = await redis.GetStringAsync(GetBasketKey(userName));
        return string.IsNullOrEmpty(basket) ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart shoppingCart)
    {
        if (string.IsNullOrWhiteSpace(shoppingCart.UserName))
            throw new ArgumentNullException("UserName must be provided.");

        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2),
        };

        var json = JsonConvert.SerializeObject(shoppingCart);
        await redis.SetStringAsync(shoppingCart.UserName, json, options);
        return await GetBasketAsync(shoppingCart.UserName);
    }

    public async Task<bool> DeleteBasketAsync(string userName)
    {
        await redis.RemoveAsync(GetBasketKey(userName));
        return true;
    }
}
