using System.Text.Json;
using Contracts.Transactions;
using Contracts.Users;

namespace Users.Repos;

public class ReturnResponseToTransactionRepo(TransactionOutboxFromUserDbContext context)
{
    public bool Return(GetUserDetails userDetails, User user)
    {
        var userDetailsResponse = new ReceiveUserDetails()
        {
            Id = new Guid(), 
            CorrelationId = userDetails.CorrelationId, 
            Payload = JsonSerializer.Serialize<User>(user)
        };
        context.ReceiveUserDetails.Add(userDetailsResponse);
        return context.SaveChanges() > 0;
    }
}