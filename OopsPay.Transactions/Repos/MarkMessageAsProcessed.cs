using Contracts;
using Contracts.Transactions;

namespace Transactions.Outbox;

public class MarkMessageAsProcessed(TransactionOutboxDbContext dbContext)
{
    public void Mark(CreateTransactions transaction)
    {
        dbContext.Update(transaction);
        dbContext.SaveChanges();
    }
}