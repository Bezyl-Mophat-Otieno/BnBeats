using BnBEats.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BnBEats.api;

public class ErrorHandlingExceptionFilterAttribute:ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is UnauthorizedException)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
                Title = "Unauthorized Access",
                Detail = context.Exception.Message,
                Status = 401
            };
            context.Result = new ObjectResult( problemDetails );
            context.HttpContext.Response.StatusCode = 401;

        }
        else if (context.Exception is NotFoundException)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "Resource Not Found",
                Detail = context.Exception.Message,
                Status = 404
            };
            context.Result = new ObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = 404;
        }
        else if (context.Exception is BadRequestException)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "Bad Request",
                Detail = context.Exception.Message,
                Status = 400
            };
            context.Result = new ObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = 400;
        }
        else
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "Internal Server Error",
                Detail = context.Exception.Message,
                Status = 500
            };
            context.Result = new ObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = 500;

        }
    }

}
