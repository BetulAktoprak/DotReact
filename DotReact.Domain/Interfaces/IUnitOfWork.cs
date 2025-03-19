namespace DotReact.Domain.Interfaces;
public interface IUnitOfWork : IAsyncDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
