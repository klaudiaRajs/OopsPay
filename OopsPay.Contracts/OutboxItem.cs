namespace Contracts;

public class OutboxItem
{
    public Guid Id { get; set; }
    public Guid CorrelationId { get; set; }
    public string Payload { get; set; }
    public DateTime? ProcessedOn { get; set; }
    public int ErrorCount { get; set; } = 0;
    
    public static TEntity Map<TEntity>(OutboxItem item)
        where TEntity : OutboxItem, new()
    {
        return new TEntity
        {
            Id = item.Id,
            CorrelationId = item.CorrelationId,
            Payload = item.Payload,
            ProcessedOn = item.ProcessedOn,
            ErrorCount = item.ErrorCount
        };
    }
}

