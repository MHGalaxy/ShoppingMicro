using Discount.Application.Protos;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Grpc.Core;
using MapsterMapper;
using MediatR;

namespace Discount.Application.Commands.Discount;

public class CreateDiscountCommand : IRequest<CouponModel>
{
    public CouponModel CouponModel { get; set; }
    public CreateDiscountCommand(CouponModel couponModel)
    {
        CouponModel = couponModel;
    }
}


public class CreateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper)
    : IRequestHandler<CreateDiscountCommand, CouponModel>
{
    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Coupon>(request.CouponModel);
        var result = await discountRepository.CreateDiscount(entity);

        if (result)
            return request.CouponModel;

        throw new RpcException(new Status(StatusCode.Internal, "Failed to create the discount."));
    }
}
