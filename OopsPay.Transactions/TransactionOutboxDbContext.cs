using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Transactions;

public class TransactionOutboxDbContext(DbContextOptions<TransactionOutboxDbContext> options) : DbContext(options)
{
    public DbSet<CreateTransactions> CreateTransactions { get; set; }
    public DbSet<ReceiveRequiredDetails> ReceiveRequiredDetails { get; set; }
}