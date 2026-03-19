using Contracts;
using Contracts.Products;
using Contracts.Users;
using Transactions.Repos;

namespace Transactions;

public class CreateTransactionWithProvidedDetails(CreateTransactionRepo createTransactionRepo)
{
    public bool Create(OutboxItem productDetailsMessage, OutboxItem userDetailsMessage, Guid correlationId)
    {
        var productDetails = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productDetailsMessage.Payload);
        var userDetails = System.Text.Json.JsonSerializer.Deserialize<User>(userDetailsMessage.Payload);
        if( productDetails == null || userDetails == null)
        {
            Console.WriteLine("Failed to deserialize product details or user details. Transaction creation aborted.");
            return false;
        }
        return createTransactionRepo.Create(productDetails, userDetails, correlationId);
    }
}