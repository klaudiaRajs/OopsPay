using System.Text.Json;
using Contracts.Users;

namespace Transactions.Outbox;

public class RequestUserDetails(TransactionOutboxDbContext dbContext)
{
    public bool Request(GetUserDetailsRequest request, Guid correlationId)
    {        
        var userDetailsRequest = new GetUserDetails()
        {
            Id = Guid.NewGuid(),
            CorrelationId = correlationId,
            Payload = JsonSerializer.Serialize(request)
        };

        dbContext.UserOutboxItems.Add(userDetailsRequest);
        //TODO dodaj handling jak coś pójdzie nie halo 
        var result = dbContext.SaveChanges();
        return result == 1; 
    }
}