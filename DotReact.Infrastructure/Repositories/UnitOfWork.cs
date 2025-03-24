using DotReact.Domain.Interfaces;
using DotReact.Infrastructure.Context;

namespace DotReact.Infrastructure.Repositories;
public class UnitOfWork(AppDbContext context, IProductRepository productRepository) : IUnitOfWork
{
    public IProductRepository ProductRepository => productRepository ??= new ProductRepository(context);

    public async ValueTask DisposeAsync()
        => await context.DisposeAsync();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
}
