using Discount.Application.Protos;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Grpc.Core;
using MapsterMapper;
using MediatR;

namespace Discount.Application.Commands.Discount;

public class UpdateDiscountCommand : IRequest<CouponModel>
{
    public CouponModel CouponModel { get; set; }

    public UpdateDiscountCommand(CouponModel couponModel)
    {
        CouponModel = couponModel;
    }
}

public class UpdateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper)
    : IRequestHandler<UpdateDiscountCommand, CouponModel>
{
    public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = mapper.Map<Coupon>(request.CouponModel);
        var result = await discountRepository.UpdateDiscount(coupon);

        if (result)
            return request.CouponModel;

        throw new RpcException(new Status(StatusCode.Internal, "Failed to update the discount."));
    }
}