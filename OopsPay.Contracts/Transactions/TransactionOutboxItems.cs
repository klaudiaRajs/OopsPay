using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Transactions;

[Table("CreateTransactions", Schema = "TransactionOutbox")]
public class CreateTransactions : OutboxItem{}
[Table("ReceiveUserDetails", Schema = "TransactionOutbox")]
public class ReceiveUserDetails : OutboxItem{}
[Table("ReceiveProductDetails", Schema = "TransactionOutbox")]
public class ReceiveProductDetails : OutboxItem{}
