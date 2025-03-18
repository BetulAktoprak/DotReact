namespace DotReact.Domain.Interfaces;
public interface IUnitOfWork : IAsyncDisposable
{
    IProductRepository ProductRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
