
namespace Contracts;

public class CreateTransactionRequest
{
    public List<int> ProductIds { get; set; }
    public Guid UserId { get; set; }
}