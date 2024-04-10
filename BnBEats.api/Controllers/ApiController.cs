
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BnBEats.api;

[ApiController]
public class ApiController:ControllerBase
{

    [Route("/error")]
    protected IActionResult Problem(List<Error> errors)
    {
        var fistError = errors[0];

        var statusCode = fistError.Type switch {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound =>StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError,

        };
      return Problem(title:fistError.Description , statusCode:statusCode);
    }
}
