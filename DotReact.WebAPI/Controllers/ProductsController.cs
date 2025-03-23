using DotReact.Application.Features.Products.Commands;
using DotReact.Application.Features.Products.Queries;
using DotReact.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotReact.WebAPI.Controllers;

public class ProductsController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        GetAllProductsQuery request = new();
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateProduct), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        GetProductByIdQuery request = new(id);
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 10, [FromQuery] int pageSize = 10, CancellationToken cancellatioToken = default)
    {
        var query = new GetPagedProductsQuery(pageNumber, pageSize);
        var (products, totalCount) = await _mediator.Send(query, cancellatioToken);

        return Ok(new
        {
            TotalCount = totalCount,
            Products = products
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductCommand command, CancellationToken cancellationToken)
    {
        if (id != command.id)
        {
            return BadRequest("Id bulunamadı");
        }
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        DeleteProductCommand request = new(id);
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }
}
