using DotReact.Domain.Interfaces;
using DotReact.Infrastructure.Context;

namespace DotReact.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IProductRepository _productRepository;

    public UnitOfWork(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
