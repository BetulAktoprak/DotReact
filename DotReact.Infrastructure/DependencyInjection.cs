using DotReact.Domain.Interfaces;
using DotReact.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotReact.Infrastructure;
public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DbContext>(options =>
        options.UseSqlite(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
