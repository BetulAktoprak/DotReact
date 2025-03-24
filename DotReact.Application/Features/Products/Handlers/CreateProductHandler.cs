using DotReact.Application.Features.Products.Commands;
using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Products.Handlers;
internal sealed class CreateProductHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProductCommand, Product>
{

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            ImageUrl = request.ImageUrl,
            IsActive = request.IsActive,
            CreatedDate = DateTime.UtcNow
        };

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product;
    }
}
