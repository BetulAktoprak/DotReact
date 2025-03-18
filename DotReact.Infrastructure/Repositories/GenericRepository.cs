using DotReact.Domain.Abstractions;
using DotReact.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DotReact.Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => await _dbSet.ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public void Update(T entity) => _dbSet.Update(entity);
}
