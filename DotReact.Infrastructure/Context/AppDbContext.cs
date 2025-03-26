using DotReact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotReact.Infrastructure.Context;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;

}
