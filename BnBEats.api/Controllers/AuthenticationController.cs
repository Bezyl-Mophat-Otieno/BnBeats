using BnBEats.application.Services.Authentication;
using BnBEats.contracts.Authentications;
using ErrorOr;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BnBEats.api.Controllers

{
    [Route("api/[controller]")]
    public class AuthenticationController: ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
            return authResult.Match(
                authResult=> Ok(authResult),
                errors => Problem(errors)

            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(
                request.Email,
                request.Password);
            return authResult.Match(
                authResult=>Ok(authResult),
                errors => Problem(errors)
            );
        }
        
    }
}
