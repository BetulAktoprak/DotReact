using DotReact.Application.Features.Products.Commands;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Products.Handlers;
internal sealed class DeleteProductHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.id, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException("Ürün bulunamadı.");
        }

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
