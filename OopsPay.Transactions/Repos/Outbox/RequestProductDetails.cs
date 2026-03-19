using Contracts.Products;
using Contracts.Transactions;

namespace Transactions.Repos.Outbox;

public class RequestProductDetails(ProductOutboxFromTransactionsDbContext productOutboxDbContext)
{
    public bool Request(CreateTransactionRequest request, Guid correlationId)
    {       
        var existingRequest = productOutboxDbContext.ProductOutboxItems.FirstOrDefault(x => x.CorrelationId == correlationId);
        if( existingRequest != null)
        {
            Console.WriteLine("A request with the same CorrelationId already exists in the outbox. Skipping creation of a new request.");
            return true; 
        }
        
        var productDetails = new GetProductDetails()
        {
            Id = Guid.NewGuid(),
            CorrelationId = correlationId,
            Payload = System.Text.Json.JsonSerializer.Serialize(new { ProductIds = request.ProductIds })
        };

        productOutboxDbContext.ProductOutboxItems.Add(productDetails);
        //TODO dodaj handling jak coś pójdzie nie halo 
        var result = productOutboxDbContext.SaveChanges();
        return result == 1; 
    }
}