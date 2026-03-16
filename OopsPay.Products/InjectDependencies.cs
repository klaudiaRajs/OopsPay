using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Outbox;
using Products.Repos;

namespace Products;

public static class InjectDependencies
{
    public static IServiceCollection AddProductDependencies(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ProductOutboxDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDbContext<TransactionOutboxFromProductDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddHostedService<GetMessagesOnLoop>(); 
        services.AddScoped<MarkMessageAsProcessed>();
        services.AddScoped<GetUnprocessedMessagesRepo>();
        services.AddScoped<GetJobsForProcessing>();
        services.AddScoped<ReturnResponseToTransactionRepo>();
        services.AddScoped<GetProductInformationFactory>();
        services.AddScoped<GetProductDetailsRepo>(); 
        return services;
    }
}