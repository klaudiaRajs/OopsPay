using Contracts;

namespace Products.Outbox;

public class MarkMessageAsProcessed(ProductOutboxDbContext dbContext)
{
    public void Mark(GetProductDetails productDetails)
    {
        dbContext.Update(productDetails);
        dbContext.SaveChanges();
    }
}