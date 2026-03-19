using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Transactions.Outbox;
using Transactions.Repos;
using Transactions.Repos.Outbox;

namespace Transactions;

public static class InjectDependencies
{
    public static IServiceCollection AddTransactionDependencies(
        this IServiceCollection services, string connectionString)
    {
        services.AddScoped<GetJobsForProcessing>();
        services.AddHostedService<GetMessagesOnLoop>(); 
        services.AddScoped<GetUnprocessedMessages>();
        services.AddScoped<MarkMessageAsProcessed>();
        services.AddScoped<RequestProductDetails>();
        services.AddScoped<RequestUserDetails>();
        services.AddScoped<CreateTransactionWithProvidedDetails>();
        services.AddScoped<RequestUserAndProductsForTransaction>();
        services.AddScoped<CreateTransactionRepo>();
        services.AddScoped<CreateTransactionService>();
        services.AddScoped<GetRequiredDataForCreatingTransaction>();
        services.AddDbContext<TransactionOutboxDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDbContext<UserOutboxFromTransactionDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDbContext<ProductOutboxFromTransactionsDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDbContext<TransactionDbContext>(options =>
            options.UseSqlServer(connectionString));
        return services;
    }
}