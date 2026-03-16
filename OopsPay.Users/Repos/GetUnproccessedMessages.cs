using Contracts.Users;

namespace Users.Outbox;

public class GetUnprocessedMessagesRepo(OutboxDbContexts dbContext)
{
    public IEnumerable<GetUserDetails> Get()
    {
        //TODO dodaj handling dla błędów i filtr na ProcessedOn
        return dbContext.GetUserDetails.Where(ct => ct.ProcessedOn == null).ToList();
    }
}