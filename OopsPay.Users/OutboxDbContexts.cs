using Contracts;
using Contracts.Transactions;
using Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace Users;

public class OutboxDbContexts(DbContextOptions<OutboxDbContexts> options) : DbContext(options)
{
    public DbSet<GetUserDetails> GetUserDetails { get; set; }
}

public class TransactionOutboxFromUserDbContext(DbContextOptions<TransactionOutboxFromUserDbContext> options): DbContext(options)
{
    public DbSet<ReceiveRequiredDetails> ReceiveRequiredDetails { get; set; }
}