using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Products;

public class ProductOutboxDbContext(DbContextOptions<ProductOutboxDbContext> options) : DbContext(options)
{
    DbSet<GetProductDetails> GetProductDetails { get; set; }
}