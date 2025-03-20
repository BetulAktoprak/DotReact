using DotReact.Application.Features.Products.Queries;
using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Products.Handlers;
internal sealed class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.GetAllAsync(cancellationToken);
    }
}
