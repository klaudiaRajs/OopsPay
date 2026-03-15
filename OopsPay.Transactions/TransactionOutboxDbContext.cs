using Contracts;
using Microsoft.EntityFrameworkCore;
using Transactions.Models;

namespace Transactions;

public class TransactionOutboxDbContext(DbContextOptions<TransactionOutboxDbContext> options) : DbContext(options)
{
    DbSet<CreateTransactions> CreateTransactions { get; set; }
    DbSet<ReceiveRequiredDetails> ReceiveRequiredDetails { get; set; }
}