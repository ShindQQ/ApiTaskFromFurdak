using ApiTask.Bll.Models.Error;

namespace ApiTaskFromFurdak.CustomMiddlewares;

public sealed class HttpStatusCodeExceptionMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<HttpStatusCodeExceptionMiddleware> _logger;

    public HttpStatusCodeExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory?.CreateLogger<HttpStatusCodeExceptionMiddleware>()
            ?? throw new ArgumentNullException(nameof(loggerFactory));
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (HttpStatusCodeException exception)
        {
            if (httpContext.Response.HasStarted)
            {
                _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                throw;
            }

            _logger.LogError(exception.Message);

            await HandleExceptionAsync(httpContext, exception);

            return;
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, HttpStatusCodeException exception)
    {
        httpContext.Response.Clear();
        httpContext.Response.StatusCode = (int)exception.HttpStatusCode;
        httpContext.Response.ContentType = exception.Message;

        await httpContext.Response.WriteAsJsonAsync(
            new HttpStatusCodeErrorDetails(((int)exception.HttpStatusCode), exception.Message).Serialize());
    }
}
