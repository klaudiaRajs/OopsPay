using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Transactions.Repos.Outbox;

public class GetRequiredDataForCreatingTransaction(TransactionOutboxDbContext dbContext)
{
    public OutboxItem? GetProductDetails(OutboxItem message)
    {
        return dbContext.ReceiveProductDetails.Where(a => a.CorrelationId == message.CorrelationId).AsNoTracking().FirstOrDefault();
    }

    public OutboxItem? GetUserDetails(OutboxItem message)
    {
        return dbContext.ReceiveUserDetails.Where(a => a.CorrelationId == message.CorrelationId).AsNoTracking().FirstOrDefault();
    }
}