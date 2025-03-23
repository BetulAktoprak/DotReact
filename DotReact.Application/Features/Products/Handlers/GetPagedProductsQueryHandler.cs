using DotReact.Application.Features.Products.Queries;
using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Products.Handlers;
internal sealed class GetPagedProductsQueryHandler(
    IProductRepository productRepository)
    : IRequestHandler<GetPagedProductsQuery, (List<Product> Products, int TotalCount)>
{
    public async Task<(List<Product> Products, int TotalCount)> Handle(GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        var (products, totalCount) = await productRepository.GetPagedAsync(request.PageNumber, request.PageSize, cancellationToken);

        return (products, totalCount);
    }
}
