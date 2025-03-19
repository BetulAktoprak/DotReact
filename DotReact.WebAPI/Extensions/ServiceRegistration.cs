using DotReact.Domain.Interfaces;
using DotReact.Infrastructure.Repositories;
using System.Reflection;

namespace DotReact.WebAPI.Extensions;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
