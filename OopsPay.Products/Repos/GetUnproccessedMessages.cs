using Contracts.Products;

namespace Products.Repos;

public class GetUnprocessedMessagesRepo(ProductOutboxDbContext dbContext)
{
    public IEnumerable<GetProductDetails> Get()
    {
        //TODO dodaj handling dla błędów i filtr na ProcessedOn
        return dbContext.GetProductDetails.Where(ct => ct.ProcessedOn == null).ToList();
    }
}