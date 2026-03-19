using System.Text.Json;
using Contracts.Products;
using Contracts.Transactions;

namespace Products.Repos;

public class ReturnResponseToTransactionRepo(TransactionOutboxFromProductDbContext context)
{
    public bool Return(GetProductDetails productDetails, List<Product> products)
    {
        var productDetailsResponse = new ReceiveProductDetails()
        {
            Id = new Guid(), 
            CorrelationId = productDetails.CorrelationId, 
            Payload = JsonSerializer.Serialize<List<Product>>(products)
        };
        context.ReceiveProductDetails.Add(productDetailsResponse);
        return context.SaveChanges() > 0;
    }
}