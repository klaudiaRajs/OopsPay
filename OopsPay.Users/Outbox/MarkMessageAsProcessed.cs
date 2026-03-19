using Contracts.Users;

namespace Users.Outbox;

public class MarkMessageAsProcessed(UserOutboxDbContext dbContext)
{
    public void Mark(GetUserDetails userDetails)
    {
        dbContext.Update(userDetails);
        dbContext.SaveChanges();
    }
}