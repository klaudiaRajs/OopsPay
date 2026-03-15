using System.Net;

namespace Contracts;

public class ErrorResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public HttpStatusCode HttpCode { get; set; }
}