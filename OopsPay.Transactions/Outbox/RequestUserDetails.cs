using System.Text.Json;
using Contracts;

namespace Transactions.Outbox;

public class RequestUserDetails(TransactionOutboxDbContext dbContext)
{
    public bool Request(CreateTransactionRequest request, Guid correlationId)
    {        
        var userDetailsRequest = new GetUserDetails()
        {
            Id = Guid.NewGuid(),
            CorrelationId = correlationId,
            Payload = System.Text.Json.JsonSerializer.Serialize(new { UserId = request.UserId })
        };

        dbContext.UserOutboxItems.Add(userDetailsRequest);
        //TODO dodaj handling jak coś pójdzie nie halo 
        var result = dbContext.SaveChanges();
        return result == 1; 
    }
}