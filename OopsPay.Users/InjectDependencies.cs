using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Users;

public static class InjectDependencies
{
    public static IServiceCollection AddUserDependencies(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<UserOutboxDbContext>(options =>
            options.UseSqlServer(connectionString));
        return services;
    }
}