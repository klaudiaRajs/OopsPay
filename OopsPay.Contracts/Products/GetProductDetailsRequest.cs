using System.Text.Json;

namespace Contracts.Products;

public class GetProductDetailsRequest
{
    public List<Guid> ProductIds { get; set; }

    public static GetProductDetailsRequest FromPayload(string payload)
    {
        return JsonSerializer.Deserialize<GetProductDetailsRequest>(payload)
               ?? new GetProductDetailsRequest();
    }
}