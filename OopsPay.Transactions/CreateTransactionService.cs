using Contracts;
using Contracts.Transactions;
using Transactions.Repos.Outbox;

namespace Transactions;

public class CreateTransactionService(
    GetRequiredDataForCreatingTransaction getRequiredData, 
    CreateTransactionWithProvidedDetails createTransaction,
    RequestUserAndProductsForTransaction requestUserAndProductsForTransaction, 
    MarkMessageAsProcessed markMessageAsProcessed
    )
{
    public bool Create(OutboxItem createTransactionMessage)
    {
        var requestDataResult = requestUserAndProductsForTransaction.Request(createTransactionMessage);
        if (!requestDataResult)
        {
            return false; 
        }
        
        var productMessage = getRequiredData.GetProductDetails(createTransactionMessage);
        var userMessage = getRequiredData.GetUserDetails(createTransactionMessage);
        if (productMessage == null || userMessage == null)
        {
            return false; 
        }
        var creationResult = createTransaction.Create(productMessage, userMessage, createTransactionMessage.CorrelationId);
        if( !creationResult )
        {
            Console.WriteLine("A problem with creating transaction occurred");
            return false; 
        }
        MarkMessagesAsProcessed(productMessage, userMessage, createTransactionMessage, creationResult);
        return creationResult; 
    }

    private void MarkMessagesAsProcessed(OutboxItem productMessage, OutboxItem userMessage, OutboxItem createTransactionMessage, bool creationResult)
    {
        markMessageAsProcessed.Mark(productMessage, nameof(ReceiveProductDetails), creationResult);
        markMessageAsProcessed.Mark(userMessage, nameof(ReceiveUserDetails), creationResult);
        markMessageAsProcessed.Mark(createTransactionMessage, nameof(CreateTransactions), creationResult);
    }
}