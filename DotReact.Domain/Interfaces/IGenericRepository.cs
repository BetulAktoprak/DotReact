using DotReact.Domain.Abstractions;
using System.Linq.Expressions;

namespace DotReact.Domain.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
