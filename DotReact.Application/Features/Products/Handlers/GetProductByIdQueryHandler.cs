using DotReact.Application.Features.Products.Queries;
using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Products.Handlers;
public sealed class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{


    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new KeyNotFoundException("Ürün bulunamadı.");
        }
        return product;
    }
}
