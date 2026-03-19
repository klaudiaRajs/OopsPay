using Contracts;
using Contracts.Transactions;

namespace Transactions.Repos.Outbox;

public class MarkMessageAsProcessed(TransactionOutboxDbContext dbContext)
{
    public bool Mark(OutboxItem message, string messageType, bool isProcessed)
    {
        switch (messageType)
        {
            case nameof(CreateTransactions):
                return MarkWithType<CreateTransactions>(message, isProcessed);
            case nameof(ReceiveProductDetails):
                return MarkWithType<ReceiveProductDetails>(message, isProcessed);
            case nameof(ReceiveUserDetails):
                return MarkWithType<ReceiveUserDetails>(message, isProcessed);
        }

        return false; 
    }

    private bool MarkWithType<TEntity>(OutboxItem item, bool isProcessed)
        where TEntity : OutboxItem, new()
    {
        var entity = OutboxItem.Map<TEntity>(item);
        var message = dbContext.Set<TEntity>().FirstOrDefault(x => x.CorrelationId == entity.CorrelationId);
        if( message == null )
        {
            Console.WriteLine($"Message with id {entity.Id} not found in database.");
            return false; 
        }
        if (isProcessed)
        {
            message.ProcessedOn = DateTime.UtcNow;
        }
        else
        {
            message.ErrorCount += 1;
        }
        dbContext.Set<TEntity>().Update(message);
        return dbContext.SaveChanges() == 1;
    }
}