using DotReact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotReact.Infrastructure.Context;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new Product
                    {
                        Id=new Guid("189e78bd-0bda-4d70-ac82-40facd2127f8"),             Name="Iphone 15",
                        Description="Telefon Açıklaması",
                        ImageUrl="1.jpg",
                        Price=70000,
                        IsActive=true,
                        Stock=100
                    },
                    new Product
                    {
                        Id=new Guid("189e78bd-0bda-4d70-ac82-40facd2127f9"),             Name="Iphone 16",
                        Description="Telefon Açıklaması",
                        ImageUrl="2.jpg",
                        Price=80000,
                        IsActive=true,
                        Stock=100
                    },
                    new Product
                    {
                        Id=new Guid("189e78bd-0bda-4d70-ac82-40facd2128f8"),             Name="Iphone 16 Pro",
                        Description="Telefon Açıklaması",
                        ImageUrl="3.jpg",
                        Price=90000,
                        IsActive=false,
                        Stock=100
                    },
                    new Product
                    {
                        Id=new Guid("189e78bd-0bda-4d70-ac82-40facd2123f8"),             Name="Iphone 16 Pro Max",
                        Description="Telefon Açıklaması",
                        ImageUrl="4.jpg",
                        Price=100000,
                        IsActive=true,
                        Stock=100
                    }
                }
            );
    }
}
