using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products;

public class ProductOutboxDbContext(DbContextOptions<ProductOutboxDbContext> options) : DbContext(options)
{
    DbSet<GetProductDetails> GetProductDetails { get; set; }
}