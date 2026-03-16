using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Outbox;
using Users.Repos;

namespace Users;

public static class InjectDependencies
{
    public static IServiceCollection AddUserDependencies(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<OutboxDbContexts>(options =>
            options.UseSqlServer(connectionString));
        services.AddDbContext<TransactionOutboxFromUserDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddHostedService<GetMessagesOnLoop>(); 
        services.AddScoped<MarkMessageAsProcessed>();
        services.AddScoped<GetUnprocessedMessages>();
        services.AddScoped<GetJobsForProcessing>();
        services.AddScoped<GetUserDetailsService>();
        services.AddScoped<GetUserDetailsRepo>();
        services.AddScoped<ReturnResponseToTransactionRepo>(); 
        return services;
    }
}