using System.Diagnostics;

namespace Contracts;

public class OutboxItem
{
    public Guid Id { get; set; }
    public Guid CorrelationId { get; set; }
    public string Payload { get; set; }
    public DateTime? ProcessedOn { get; set; }
    public int ErrorCount { get; set; } = 0;
}

