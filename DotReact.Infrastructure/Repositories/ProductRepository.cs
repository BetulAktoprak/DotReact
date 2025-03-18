using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotReact.Infrastructure.Repositories;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly DbContext _context;
    public ProductRepository(DbContext context) : base(context)
    {
        _context = context;
    }
}
