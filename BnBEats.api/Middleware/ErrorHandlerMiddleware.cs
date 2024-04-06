using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;
using BnBEats.domain;

namespace BnBEats.api;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected

        if (exception is NotFoundException) code = HttpStatusCode.NotFound;
        else if (exception is UnauthorizedException) code = HttpStatusCode.Unauthorized;
        else if (exception is BadRequestException) code = HttpStatusCode.BadRequest;

        var result = JsonSerializer.Serialize(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }

}


