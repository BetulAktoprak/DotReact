using DotReact.Application.Features.Products.Commands;
using DotReact.Application.Features.Products.Queries;
using DotReact.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotReact.WebAPI.Controllers;

public class ProductsController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var product = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateProduct), new { id = product.Id }, product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}
