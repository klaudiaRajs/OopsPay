using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Transactions;

[Table("Transactions", Schema = "Transaction")]
public class Transaction
{
    public Guid Id { get; set; }
    public Guid CorrelationId { get; set; }
    public string UserSnapshot { get; set; }
    public string Products { get; set; }
}