using System.Net;

namespace ApiTask.Bll.Models.Error;

public sealed class HttpStatusCodeException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }

    public HttpStatusCodeException(string message)
        : base(message)
    {
        HttpStatusCode = HttpStatusCode.BadRequest;
    }

    public HttpStatusCodeException(HttpStatusCode httpStatusCode, string message)
        : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}
