using System.Text.Json;

namespace Contracts.Users;

public class GetUserDetailsRequest
{
    public Guid? UserId { get; set; }
    public Guid CorrelationId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public static GetUserDetailsRequest FromPayload(string payload)
    {
        return JsonSerializer.Deserialize<GetUserDetailsRequest>(payload)
               ?? new GetUserDetailsRequest();
        /*var deserializedPayload = JsonSerializer.Deserialize<GetUserDetailsRequest>(payload);
        UserId = deserializedPayload?.UserId;
        CorrelationId = deserializedPayload?.CorrelationId ?? Guid.Empty;
        Name = deserializedPayload?.Name;
        Surname = deserializedPayload?.Surname;
        Email = deserializedPayload?.Email;
        Address = deserializedPayload?.Address;*/
    }
}