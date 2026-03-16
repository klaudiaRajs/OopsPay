using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Transactions.Outbox;

namespace Transactions;

public static class InjectDependencies
{
    public static IServiceCollection AddTransactionDependencies(
        this IServiceCollection services, string connectionString)
    {
        services.AddScoped<MarkMessageAsProcessed>();
        services.AddScoped<GetUnprocessedMessages>();
        services.AddScoped<RequestDataForTransaction>();
        services.AddScoped<GetJobsForProcessing>();
        services.AddScoped<RequestUserDetails>();
        services.AddScoped<RequestProductDetails>();
        services.AddHostedService<GetMessagesOnLoop>(); 
        services.AddDbContext<TransactionOutboxDbContext>(options =>
            options.UseSqlServer(connectionString));
        return services;
    }
}