using Contracts.Products;
using Contracts.Transactions;
using Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace Transactions;

public class TransactionOutboxDbContext(DbContextOptions<TransactionOutboxDbContext> options) : DbContext(options)
{
    public DbSet<CreateTransactions> CreateTransactions { get; set; }
    public DbSet<ReceiveProductDetails> ReceiveProductDetails { get; set; }
    public DbSet<ReceiveUserDetails> ReceiveUserDetails { get; set; }
}

public class UserOutboxFromTransactionDbContext(DbContextOptions<UserOutboxFromTransactionDbContext> options) : DbContext(options)
{
    public DbSet<GetUserDetails> UserOutboxItems { get; set; }
}

public class ProductOutboxFromTransactionsDbContext(DbContextOptions<ProductOutboxFromTransactionsDbContext> options) : DbContext(options)
{
    public DbSet<GetProductDetails> ProductOutboxItems { get; set; }
}