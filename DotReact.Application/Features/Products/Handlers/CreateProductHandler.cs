using DotReact.Application.Features.Products.Commands;
using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Products.Handlers;
public sealed class CreateProductHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

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

        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product;
    }
}
