using DotReact.Domain.Entities;
using MediatR;

namespace DotReact.Application.Features.Products.Commands;
public sealed class CreateProductCommand : IRequest<Product>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }
}
