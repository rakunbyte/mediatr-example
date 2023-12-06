using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Commands;
using Models.Requests;

namespace WebApi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => _mediator = mediator;
}


[ApiController]
[Route("Api/")]
public class ProductController(IMediator mediator) : Controller
{
    [HttpGet]
    [Route("GetProducts")]
    public async Task<ActionResult> GetProducts()
    {
        var products = await mediator.Send(new GetProductsQuery());
        return Ok(products);
    }
    
    [HttpGet]
    [Route("GetProductById", Name = "GetProductById")]
    public async Task<ActionResult> GetProductById([FromQuery]long id)
    {
        var product = await mediator.Send(new GetProductByIdQuery(id));
        return product is null ? NotFound() : Ok(product);
    }
    
    [HttpPost]
    [Route("AddProduct")]
    public async Task<ActionResult> AddProduct([FromBody]Product product)
    {
        await mediator.Send(new AddProductCommand(product));
        var result = CreatedAtRoute("GetProductById", new {id = product.Id}, product);
        return result;
    }
}