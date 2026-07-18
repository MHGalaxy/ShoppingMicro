using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Commands.Discount;

public class DeleteDiscountByProductNameCommand : IRequest<bool>
{
    public string ProductName { get; set; }

    public DeleteDiscountByProductNameCommand(string productName)
    {
        ProductName = productName;
    }
}

public class DeleteDiscountByProductNameCommandHandler(IDiscountRepository discountRepository)
    : IRequestHandler<DeleteDiscountByProductNameCommand, bool>
{
    public async Task<bool> Handle(DeleteDiscountByProductNameCommand request, CancellationToken cancellationToken)
    {
        return await discountRepository.DeleteDiscountByProductName(request.ProductName);
    }
}