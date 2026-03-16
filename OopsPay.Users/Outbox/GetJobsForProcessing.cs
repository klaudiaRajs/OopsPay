namespace Users.Outbox;

public class GetJobsForProcessing(
    GetUnprocessedMessages getJobsForProcessing,
    MarkMessageAsProcessed markMessageAsProcessed, 
    GetUserDetailsService getUserDetailsService) 
{
    public bool Get(CancellationToken cancellationToken)
    {
        try
        {
            var unproccessedRequests = getJobsForProcessing.Get();
            foreach (var request in unproccessedRequests)
            {
                var success = getUserDetailsService.Get(request);
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