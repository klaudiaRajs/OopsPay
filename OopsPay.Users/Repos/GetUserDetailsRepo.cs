using Contracts.Users;

namespace Users.Repos;

public class GetUserDetailsRepo(UserDbContext context)
{
    public User? Get(GetUserDetailsRequest request)
    {
        return new User
        {
            UserId = Guid.NewGuid(),
            Name = "Anna",
            Surname = "Nowak",
            Email = "anna.nowak@example.com",
            Address = "ul. Piękna 22, 00-549 Warszawa"
        };
        if (request.UserId != null)
        {
            return context.Users.FirstOrDefault(u => u.UserId == request.UserId);
        }
        if( request.Email != null)
        {
            return context.Users.FirstOrDefault(u => u.Email == request.Email);
        }

        return null;
    }
}