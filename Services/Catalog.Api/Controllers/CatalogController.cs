using Catalog.Application.Commands.Product;
using Catalog.Application.Queries.Product;
using Catalog.Application.Queries.ProductBrand;
using Catalog.Application.Queries.ProductType;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

public class CatalogController(IMediator mediator) : ApiController
{

    //IActiionResult: unknown output type
    //ActiionResult: with output type

    // api/v1.0/catalog/GetAllProducts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllProductsQuery(), cancellationToken));
    }

    // api/v1.0/catalog/GetProductById/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProductById(string id, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductByIdQuery(id), cancellationToken));
    }

    // api/v1.0/catalog/GetProductsByName/{name}
    [HttpGet("{name}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByName(string name, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductsByNameQuery(name), cancellationToken));
    }

    // api/v1.0/catalog/GetProductsByBrandName/{brandName}
    [HttpGet("{brandName}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByBrandName(string brandName, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductsByBrandQuery(brandName), cancellationToken));
    }

    // api/v1.0/catalog/GetProductsByBrandId/{brandId}
    [HttpGet("{brandId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByBrandId(string brandId, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductsByBrandIdQuery(brandId), cancellationToken));
    }

    // api/v1.0/catalog/GetProductsByTypeName/{typeName}
    [HttpGet("{typeName}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByTypeName(string typeName, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductsByTypeQuery(typeName), cancellationToken));
    }

    // api/v1.0/catalog/GetProductsByTypeId/{typeId}
    [HttpGet("{typeId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByTypeId(string typeId, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetProductsByTypeIdQuery(typeId), cancellationToken));
    }

    // api/v1.0/catalog/GetAllProductBrands
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductBrandDto>>> GetAllProductBrands(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllProductBrandsQuery(), cancellationToken));
    }

    // api/v1.0/catalog/GetAllProductTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductTypeDto>>> GetAllProductTypes(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllProductTypesQuery(), cancellationToken));
    }

    // api/v1.0/catalog/CreateProduct
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(command, cancellationToken));
    }

    // api/v1.0/catalog/UpdateProduct
    [HttpPut]
    public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand command, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(command, cancellationToken));
    }

    // api/v1.0/catalog/DeleteProduct/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteProduct([FromBody] string id, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new DeleteProductCommand(id), cancellationToken));
    }
}
