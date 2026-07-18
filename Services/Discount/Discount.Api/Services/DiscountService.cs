using Discount.Application.Commands.Discount;
using Discount.Application.Protos;
using Discount.Application.Queries.Discount;
using Grpc.Core;
using MediatR;

namespace Discount.Api.Services;

public class DiscountService(IMediator mediator) : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscountByProductId(GetDiscountByProductIdRequest request, ServerCallContext context)
    {
        var query = new GetDiscountByNameQuery(request.ProductId);
        return await mediator.Send(query);
    }

    public override async Task<CouponModel> GetDiscountByProductName(GetDiscountByProductNameRequest request, ServerCallContext context)
    {
        var query = new GetDiscountByNameQuery(request.ProductName);
        return await mediator.Send(query);
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var command = new CreateDiscountCommand(request.Coupon);
        return await mediator.Send(command);
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var command = new UpdateDiscountCommand(request.Coupon);
        return await mediator.Send(command);
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscountByProductId(DeleteDiscountByProductIdRequest request, ServerCallContext context)
    {
        var command = new DeleteDiscountByProductIdCommand(request.ProductId);
        var result = await mediator.Send(command);
        return new DeleteDiscountResponse
        {
            Success = result
        }; 
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscountByProductName(DeleteDiscountByProductNameRequest request, ServerCallContext context)
    {
        var command = new DeleteDiscountByProductNameCommand(request.ProductName);
        var result = await mediator.Send(command);
        return new DeleteDiscountResponse
        {
            Success = result
        };
    }
}
