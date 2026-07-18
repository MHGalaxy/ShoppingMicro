using Discount.Core.Entities;
using Discount.Application.Protos;
using Mapster;

namespace Discount.Application.Mapping;

public class DiscountMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Coupon, CouponModel>();
        config.NewConfig<CouponModel, Coupon>();
    }
}
