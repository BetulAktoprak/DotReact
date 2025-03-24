using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using DotReact.Infrastructure.Context;

namespace DotReact.Infrastructure.Repositories;
public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
{
}
