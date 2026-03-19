using Contracts.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Transactions;

public class TransactionDbContext(DbContextOptions<TransactionDbContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }
}