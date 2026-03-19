using Products.Repos;

namespace Products.Outbox;

public class GetJobsForProcessing(
    GetUnprocessedMessagesRepo getUnprocessedMessagesRepo,
    MarkMessageAsProcessed markMessageAsProcessed, 
    GetProductInformationFactory getProductDetailsFactory) 
{
    public bool Get(CancellationToken cancellationToken)
    {
        try
        {
            var unproccessedRequests = getUnprocessedMessagesRepo.Get();
            foreach (var request in unproccessedRequests)
            {
                var success = getProductDetailsFactory.Get(request);
                if (success)
                {
                    request.ProcessedOn = DateTime.UtcNow;
                }
                else
                {
                    request.ErrorCount += 1;
                }

                markMessageAsProcessed.Mark(request);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing request: {ex.Message}");
            return false;
        }

        return true;
    }
}