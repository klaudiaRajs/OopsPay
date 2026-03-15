using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users;

public class UserOutboxDbContext(DbContextOptions<UserOutboxDbContext> options) : DbContext(options)
{
    DbSet<GetUserDetails> GetUserDetails { get; set; }
}