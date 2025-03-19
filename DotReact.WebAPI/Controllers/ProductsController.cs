using DotReact.Application.Features.Products.Commands;
using DotReact.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotReact.WebAPI.Controllers;

public class ProductsController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var product = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateProduct), new { id = product.Id }, product);
    }
}
