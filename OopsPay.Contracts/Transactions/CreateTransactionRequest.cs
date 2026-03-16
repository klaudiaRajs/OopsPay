
using System.Text.Json;

namespace Contracts;

public class CreateTransactionRequest
{
    public List<int> ProductIds { get; set; }
    public Guid UserId { get; set; }

    public CreateTransactionRequest()
    {
        
    }
    public CreateTransactionRequest(string payload)
    {
        var deserializedPayload = JsonSerializer.Deserialize<CreateTransactionRequest>(payload);
        ProductIds = deserializedPayload?.ProductIds ?? new List<int>();
        UserId = deserializedPayload?.UserId ?? Guid.Empty; 
    }
}