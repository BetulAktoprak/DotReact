using FluentValidation;
using System.Net;
using System.Text.Json;

namespace DotReact.WebAPI.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate request)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await request(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string result;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                var errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                result = JsonSerializer.Serialize(new { message = "Validasyon hatası", errors });
                break;
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new { message = exception.Message });
                break;
            default:
                result = JsonSerializer.Serialize(new { message = "Beklenmeyen bir hata oluştu." });
                break;
        }
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}
