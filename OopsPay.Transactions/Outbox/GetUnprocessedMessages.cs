using Contracts;

namespace Transactions.Outbox;

public class GetUnprocessedMessages(TransactionOutboxDbContext dbContext)
{
    public IEnumerable<CreateTransactions> Get()
    {
        //TODO dodaj handling dla błędów i filtr na ProcessedOn
        return dbContext.CreateTransactions.Where(ct => ct.ProcessedOn == null).ToList();
    }
}