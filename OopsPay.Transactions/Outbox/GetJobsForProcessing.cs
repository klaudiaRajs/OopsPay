using Transactions.Outbox;

namespace Transactions;

public class GetJobsForProcessing(
    GetUnprocessedMessages getJobsForProcessing,
    MarkMessageAsProcessed markMessageAsProcessed,
    RequestDataForTransaction requestDataForTransaction)
{
    public async Task Get(CancellationToken cancellationToken)
    {
        try
        {
            var unprocessedTransactions = getJobsForProcessing.Get();
            foreach (var transaction in unprocessedTransactions)
            {
                var success = requestDataForTransaction.Request(transaction);
                if (success)
                {
                    transaction.ProcessedOn = DateTime.UtcNow;
                }
                else
                {
                    transaction.ErrorCount += 1;
                }

                markMessageAsProcessed.Mark(transaction);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing transactions: {ex.Message}");
        }
    }
}