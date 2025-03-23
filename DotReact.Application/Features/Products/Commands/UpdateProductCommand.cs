using DotReact.Domain.Entities;
using MediatR;

namespace DotReact.Application.Features.Products.Commands;
public sealed record UpdateProductCommand(
    Guid id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string ImageUrl,
    bool IsActive) : IRequest<Product>;

