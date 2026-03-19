using Contracts.Transactions;

namespace OopsPay;

public class CreateTransaction(TransactionRepository repository)
{
    public Task<CreateTransactionResponse?> Create(CreateTransactionRequest request)
    {
        var response = repository.TriggerCreation(request);
        return Task.FromResult(response); 
    }
}