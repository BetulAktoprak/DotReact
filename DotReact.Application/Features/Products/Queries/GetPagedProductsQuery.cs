using DotReact.Domain.Entities;
using MediatR;

namespace DotReact.Application.Features.Products.Queries;
public sealed record GetPagedProductsQuery(int PageNumber, int PageSize) : IRequest<(List<Product> Products, int TotalCount)>;
