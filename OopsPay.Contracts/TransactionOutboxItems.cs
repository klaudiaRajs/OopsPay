using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts;

[Table("CreateTransactions", Schema = "TransactionOutbox")]
public class CreateTransactions : OutboxItem{}
public class ReceiveRequiredDetails : OutboxItem{}
