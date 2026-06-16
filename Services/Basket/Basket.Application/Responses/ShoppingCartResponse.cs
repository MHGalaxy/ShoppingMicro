using Basket.Core.Entities;

namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public ShoppingCartResponse()
    {
        
    }

    public ShoppingCartResponse(string userName)
    {
        UserName = userName;
    }

    public Guid Guid { get; set; }
    public string UserName { get; set; } 
    public string UserId { get; set; } 
    public List<ShoppingCartItem> Items { get; set; } = []; 
    public decimal CalculateOriginalPrice() => Items.Sum(x => x.Quantity * x.Price);
}
