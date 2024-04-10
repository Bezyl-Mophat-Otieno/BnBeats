using BnBEats.application;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BnBEats.api;

public class ErrorsController:ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception ? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IDuplicateEmailException duplicateEmailException => ((int)duplicateEmailException.StatusCode,duplicateEmailException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError,"Internal Server Error")
        };
        return Problem(  detail: message, statusCode: statusCode);
    }
}
