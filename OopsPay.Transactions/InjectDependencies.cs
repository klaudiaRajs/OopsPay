using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Transactions;

public static class InjectDependencies
{
    public static IServiceCollection AddTransactionDependencies(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TransactionOutboxDbContext>(options =>
            options.UseSqlServer(connectionString));
        return services;
    }
}