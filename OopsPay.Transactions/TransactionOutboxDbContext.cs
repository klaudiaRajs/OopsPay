using Contracts;
using Contracts.Transactions;
using Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace Transactions;

public class TransactionOutboxDbContext(DbContextOptions<TransactionOutboxDbContext> options) : DbContext(options)
{
    public DbSet<CreateTransactions> CreateTransactions { get; set; }
    public DbSet<ReceiveRequiredDetails> ReceiveRequiredDetails { get; set; }
    public DbSet<GetUserDetails> UserOutboxItems { get; set; }
    public DbSet<GetProductDetails> ProductOutboxItems { get; set; }
}