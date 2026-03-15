using Contracts;

namespace Transactions.Outbox;

public class RequestProductDetails(TransactionOutboxDbContext dbContext)
{
    public bool Request(CreateTransactionRequest request, Guid correlationId)
    {        
        var productDetails = new GetProductDetails()
        {
            Id = Guid.NewGuid(),
            CorrelationId = correlationId,
            Payload = System.Text.Json.JsonSerializer.Serialize(new { ProductIds = request.ProductIds })
        };

        dbContext.ProductOutboxItems.Add(productDetails);
        //TODO dodaj handling jak coś pójdzie nie halo 
        var result = dbContext.SaveChanges();
        return result == 1; 
    }
}