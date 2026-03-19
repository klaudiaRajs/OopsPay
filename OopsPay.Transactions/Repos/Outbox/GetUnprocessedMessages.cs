using Contracts;
using Contracts.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Transactions.Repos.Outbox;

public class GetUnprocessedMessages(TransactionOutboxDbContext dbContext)
{
    public Dictionary<string, IEnumerable<OutboxItem>> Get()
    {
        var createTransactions = this.Get<CreateTransactions>(); 
        return createTransactions
            .ToDictionary(x => x.Key, x => x.Value);
    }
    
    private Dictionary<string, IEnumerable<OutboxItem>> Get<T>() where T : OutboxItem
    {
        var items = dbContext.Set<T>()
            .Where(x => x.ProcessedOn == null)
            .AsNoTracking()
            .Cast<OutboxItem>()
            .ToList();
        return new Dictionary<string, IEnumerable<OutboxItem>>
        {
            { typeof(T).Name, items }
        }; 
    }
}