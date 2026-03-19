using Contracts.Transactions;
using Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace Users;

public class UserOutboxDbContext(DbContextOptions<UserOutboxDbContext> options) : DbContext(options)
{
    public DbSet<GetUserDetails> GetUserDetails { get; set; }
}

public class TransactionOutboxFromUserDbContext(DbContextOptions<TransactionOutboxFromUserDbContext> options): DbContext(options)
{
    public DbSet<ReceiveUserDetails> ReceiveUserDetails { get; set; }
}