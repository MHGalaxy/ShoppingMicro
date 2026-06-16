using Basket.Application.Commands.Basket;
using Basket.Application.Queries.Basket;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

public class BasketController(IMediator mediator) : ApiController
{
    // api/v1/Basket/GetBasketByUserName
    [HttpGet("{userName}")]
    public async Task<ActionResult<ShoppingCartResponse>> GetBasketByUserName(string userName, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetBasketByUserNameQuery(userName), cancellationToken));
    }

    // api/v1/Basket/CreateBasket
    [HttpPost]
    public async Task<ActionResult<ShoppingCartResponse>> CreateBasket([FromBody] CreateBasketCommand request, CancellationToken cancellationToken) 
    {
        return Ok(await mediator.Send(request, cancellationToken));
    }

    // api/v1/Basket/DeleteBasket
    [HttpDelete("{userName}")]
    public async Task<ActionResult<bool>> DeleteBasket(string userName, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new DeleteBasketCommand(userName), cancellationToken));
    }
}
