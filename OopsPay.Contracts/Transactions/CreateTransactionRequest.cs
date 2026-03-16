
using System.Text.Json;

namespace Contracts;

public class CreateTransactionRequest
{
    public List<string> ProductIds { get; set; }
    public Guid UserId { get; set; }

    public CreateTransactionRequest()
    {
        
    }
    public CreateTransactionRequest(string payload)
    {
        var deserializedPayload = JsonSerializer.Deserialize<CreateTransactionRequest>(payload);
        ProductIds = deserializedPayload?.ProductIds ?? new List<string>();
        UserId = deserializedPayload?.UserId ?? Guid.Empty; 
    }
}