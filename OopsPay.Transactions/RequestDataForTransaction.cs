using Contracts;
using Contracts.Transactions;
using Contracts.Users;
using Transactions.Outbox;

namespace Transactions;

public class RequestDataForTransaction(
    RequestUserDetails requestUserDetails,
    RequestProductDetails requestProductDetails)
{
    public bool Request(CreateTransactions transaction)
    {
        try
        {
            var userDetailsRequestSent = RequestUserDetails(transaction);
            var productDetailsRequestSent = RequestProductDetails(transaction);
            if (userDetailsRequestSent && productDetailsRequestSent)
            {
                Console.WriteLine("Both user details and product details requests sent successfully.");
            }
            else
            {
                Console.WriteLine("Failed to send one or both requests. User details request sent: " +
                                  userDetailsRequestSent + ", Product details request sent: " +
                                  productDetailsRequestSent);
            }

            return userDetailsRequestSent && productDetailsRequestSent;
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Error requesting data for transaction with CorrelationId {transaction.CorrelationId}: {ex.Message}");
            return false;
        }
    }


    private bool RequestProductDetails(CreateTransactions transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));

        var transactionRequest = new CreateTransactionRequest(transaction.Payload);
        if (!transactionRequest.ProductIds.Any())
        {
            Console.WriteLine("ProductIds are null or empty. Cannot send request.");
            return false;
        }

        var success = requestProductDetails.Request(transactionRequest, transaction.CorrelationId);
        Console.WriteLine($"Request for product details sent to outbox with result: {success}");
        return success;
    }

    private bool RequestUserDetails(CreateTransactions transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));

        var transactionRequest = GetUserDetailsRequest.FromPayload(transaction.Payload);
        var success = requestUserDetails.Request(transactionRequest, transaction.CorrelationId);
        Console.WriteLine($"Request for user details sent to outbox with result: {success}");
        return success;
    }
}