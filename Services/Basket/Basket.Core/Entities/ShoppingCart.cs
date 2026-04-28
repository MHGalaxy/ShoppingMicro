namespace Basket.Core.Entities;

public class ShoppingCart(string userName, string userId)
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public string UserName { get; set; } = userName;
    public string UserId { get; set; } = userId;
    public List<ShoppingCartItem> Items { get; set; } = []; // new();
    public decimal CalculateOriginalPrice() => Items.Sum(x => x.Quantity * x.Price);
}
