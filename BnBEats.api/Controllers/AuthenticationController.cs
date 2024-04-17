using BnBEats.application.Services.Authentication;
using BnBEats.contracts.Authentications;
using ErrorOr;
using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BnBEats.api.Controllers

{
    [Route("api/[controller]")]
    public class AuthenticationController: ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService, IMapper mapper)
        {
            _authenticationCommandService = authenticationCommandService;
            _authenticationQueryService = authenticationQueryService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
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
            ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(
                request.Email,
                request.Password);
            return authResult.Match(
                authResult=>Ok(authResult),
                errors => Problem(errors)
            );
        }
        
    }
}
