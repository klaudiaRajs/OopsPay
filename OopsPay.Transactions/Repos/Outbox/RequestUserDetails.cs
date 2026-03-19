using System.Text.Json;
using Contracts.Users;

namespace Transactions.Repos.Outbox;

public class RequestUserDetails(UserOutboxFromTransactionDbContext dbContext)
{
    public bool Request(GetUserDetailsRequest request, Guid correlationId)
    {       
        var existingRequest = dbContext.UserOutboxItems.FirstOrDefault(x => x.CorrelationId == correlationId);
        if( existingRequest != null)
        {
            Console.WriteLine("A request with the same CorrelationId already exists in the outbox. Skipping creation of a new request.");
            return true; 
        }
        var userDetailsRequest = new GetUserDetails()
        {
            Id = Guid.NewGuid(),
            CorrelationId = correlationId,
            Payload = JsonSerializer.Serialize(request)
        };

        dbContext.UserOutboxItems.Add(userDetailsRequest);
        var result = dbContext.SaveChanges();
        return result == 1; 
    }
}