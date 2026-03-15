using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Users;

public class UserOutboxDbContext(DbContextOptions<UserOutboxDbContext> options) : DbContext(options)
{
    DbSet<GetUserDetails> GetUserDetails { get; set; }
}