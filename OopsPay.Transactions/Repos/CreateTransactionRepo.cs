using System.Text.Json;
using Contracts.Products;
using Contracts.Transactions;
using Contracts.Users;

namespace Transactions.Repos;

public class CreateTransactionRepo(TransactionDbContext transactionDbContext, TransactionOutboxDbContext transactionOutboxDbContext)
{
    public bool Create(List<Product> productDetails, User userDetails, Guid correlationId)
    {
        var transaction = new Transaction
        {
            CorrelationId = correlationId,
            UserSnapshot = JsonSerializer.Serialize(userDetails),
            Products = JsonSerializer.Serialize(productDetails)
        }; 
        var existingTransaction = transactionDbContext.Transactions.FirstOrDefault(x => x.CorrelationId == correlationId);
        if( existingTransaction != null)
        {
            Console.WriteLine("A transaction with the same CorrelationId already exists. Skipping creation of a new transaction.");
            return true; 
        }
        transactionDbContext.Transactions.Add(transaction);
        var result = transactionDbContext.SaveChanges();    
        
        return result == 1;
    }
}