using Contracts;
using Contracts.Transactions;
using Transactions.Repos.Outbox;

namespace Transactions.Outbox;

public class GetJobsForProcessing(
    GetUnprocessedMessages getUnprocessedMessages,
    MarkMessageAsProcessed markMessageAsProcessed,
    CreateTransactionService createTransactionService
     )
{
    public void Get(CancellationToken cancellationToken)
    {
        try
        {
            var unprocessedTransactions = getUnprocessedMessages.Get();
            foreach (var messageGroup in unprocessedTransactions)
            {
                messageGroup.Value.ToList().ForEach(message => HandleMessageBasedOnType(message, messageGroup.Key));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing transactions: {ex.Message}");
        }
    }

    private bool HandleMessageBasedOnType(OutboxItem message, string messageType)
    {
        switch(messageType)
        {
            case nameof(CreateTransactions):
                return createTransactionService.Create(message); 
            default:
                Console.WriteLine($"Unknown message type: {messageType}. Skipping.");
                return false; 
        }
    }
}