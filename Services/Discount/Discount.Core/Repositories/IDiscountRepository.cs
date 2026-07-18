using Discount.Core.Entities;

namespace Discount.Core.Repositories;

public interface IDiscountRepository
{
    Task<Coupon> GetDiscountByProductId(string productId);
    Task<Coupon> GetDiscountByProductName(string productName);
    Task<bool> CreateDiscount(Coupon coupon);
    Task<bool> UpdateDiscount(Coupon coupon);
    Task<bool> DeleteDiscountByProductId(string productId);
    Task<bool> DeleteDiscountByProductName(string productName);
}
