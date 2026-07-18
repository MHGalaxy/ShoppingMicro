using Discount.Application.Protos;
using Discount.Core.Repositories;
using Grpc.Core;
using MapsterMapper;
using MediatR;

namespace Discount.Application.Queries.Discount;

public class GetDiscountByNameQuery : IRequest<CouponModel>
{
    public string ProductName { get; set; }
    public GetDiscountByNameQuery(string productName)
    {
        ProductName = productName;
    }
}

public class GetDiscountByNameQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
    : IRequestHandler<GetDiscountByNameQuery, CouponModel>
{
    public async Task<CouponModel> Handle(GetDiscountByNameQuery request, CancellationToken cancellationToken)
    {
        var entity = await discountRepository.GetDiscountByProductName(request.ProductName);

        if (entity == null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found for product name: {request.ProductName}"));

        return mapper.Map<CouponModel>(entity);
    }
}
