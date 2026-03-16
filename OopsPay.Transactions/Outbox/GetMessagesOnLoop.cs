using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Transactions;

public class GetMessagesOnLoop(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(40), stoppingToken);
            try
            {
                using var scope = serviceProvider.CreateScope();
                var processor = scope.ServiceProvider.GetRequiredService<GetJobsForProcessing>();
                await processor.Get(stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Outbox error: {ex}");
            }

        }

        Console.WriteLine("Outbox worker stopped");
    }
}