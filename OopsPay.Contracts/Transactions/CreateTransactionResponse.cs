namespace Contracts;

public class CreateTransactionResponse
{
    public Guid CorrelationId { get; set; }
    public string Status { get; set; }
    public CreateTransactionRequest Payload { get; set; }
    public ErrorResponse? Errors { get; set; }
}