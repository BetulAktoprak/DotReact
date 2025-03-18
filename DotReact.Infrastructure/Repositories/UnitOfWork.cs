using DotReact.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotReact.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private IProductRepository _productRepository;

    public UnitOfWork(DbContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public IProductRepository ProductRepository
        => _productRepository ??= new ProductRepository(_context);

    public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
