using Contracts.Products;
using Contracts.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Products;

public class ProductOutboxDbContext(DbContextOptions<ProductOutboxDbContext> options) : DbContext(options)
{
    public DbSet<GetProductDetails> GetProductDetails { get; set; }
}

public class TransactionOutboxFromProductDbContext(DbContextOptions<TransactionOutboxFromProductDbContext> options): DbContext(options)
{
    public DbSet<ReceiveProductDetails> ReceiveProductDetails { get; set; }
}