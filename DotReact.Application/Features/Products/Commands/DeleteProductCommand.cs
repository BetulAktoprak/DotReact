using MediatR;

namespace DotReact.Application.Features.Products.Commands;
public sealed record DeleteProductCommand(Guid id) : IRequest;
