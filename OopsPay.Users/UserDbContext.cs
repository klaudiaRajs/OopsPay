using Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace Users;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}