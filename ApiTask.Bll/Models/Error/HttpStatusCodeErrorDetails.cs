using System.Text.Json;

namespace ApiTask.Bll.Models.Error;

public sealed class HttpStatusCodeErrorDetails
{
    public int StatusCode { get; set; }

    public string ErrorMessage { get; set; }

    public HttpStatusCodeErrorDetails(int statusCode, string errorMessage)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }

    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
}
