using BnBEats.application;
using BnBEats.application.Services.Authentication;

namespace BnBEata.application.Services.Authentication 
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {

            var userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName, email);
            return new AuthenticationResult( userId,firstName, lastName,email,token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "token");
        }
    }
}