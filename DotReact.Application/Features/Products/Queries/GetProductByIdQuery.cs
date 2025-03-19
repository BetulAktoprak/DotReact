using DotReact.Domain.Entities;
using MediatR;

namespace DotReact.Application.Features.Products.Queries;
public class GetProductByIdQuery : IRequest<Product>
{
    public GetProductByIdQuery(Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
}
