using System.Net;
using Contracts;
using Contracts.Transactions;
using Transactions;

namespace OopsPay;

public class TransactionRepository(TransactionOutboxDbContext dbContext)
{
    public CreateTransactionResponse? TriggerCreation(CreateTransactionRequest request)
    {
        try
        {
            var createTransaction = BuildCreateTransaction(request);
            dbContext.CreateTransactions.Add(createTransaction);
            dbContext.SaveChanges();

            return BuildSuccessResponse(createTransaction, request);
        }
        catch (Exception ex)
        {
            // TODO: Add logger
            return BuildErrorResponse(ex);
        }
    }

    private CreateTransactions BuildCreateTransaction(CreateTransactionRequest request)
    {
        return new CreateTransactions
        {
            Id = Guid.NewGuid(),
            CorrelationId = Guid.NewGuid(),
            Payload = System.Text.Json.JsonSerializer.Serialize(request)
        };
    }

    private CreateTransactionResponse BuildSuccessResponse(CreateTransactions transaction, CreateTransactionRequest request)
    {
        return new CreateTransactionResponse
        {
            CorrelationId = transaction.CorrelationId,
            Payload = request,
            Status = "CreationTriggered"
        };
    }

    private CreateTransactionResponse BuildErrorResponse(Exception ex)
    {
        return new CreateTransactionResponse
        {
            Errors = new ErrorResponse
            {
                Success = false,
                Message = ex.Message,
                HttpCode = HttpStatusCode.InternalServerError
            }
        };
    }
}