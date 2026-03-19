using System.Text.Json;
using Contracts.Products;
using Contracts.Users;

namespace Contracts.Transactions;

public class CreateTransactionWithDetailsRequest
{
    public GetUserDetailsRequest? UserDetails { get; set; }
    public GetProductDetailsRequest? ProductDetails { get; set; }
    public Guid CorrelationId { get; set; }

    public static CreateTransactionWithDetailsRequest FromPayload(string productsPayload, string userPayloads, Guid correlationId)
    {
        var productDetails = JsonSerializer.Deserialize<GetProductDetailsRequest>(productsPayload);
        var userDetails = JsonSerializer.Deserialize<GetUserDetailsRequest>(userPayloads);

        return new CreateTransactionWithDetailsRequest
        {
            ProductDetails = productDetails,
            UserDetails = userDetails,
            CorrelationId = correlationId
        };
    }
}