using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Products;

public static class InjectDependencies
{
    public static IServiceCollection AddProductDependencies(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ProductOutboxDbContext>(options =>
            options.UseSqlServer(connectionString));
        return services;
    }
}