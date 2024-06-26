using BnBEats.application;
using BnBEats.application.Services.Authentication;
using BnBEats.application.Services.Authentication.Common;
using BnBEats.domain;
using ErrorOr;

namespace BnBEata.application.Services.Authentication 
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository  _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator , IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;

        }

        public ErrorOr<AuthenticationResult>  Login(string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) is not User user){
                return Errors.Authentication.IncorrectPassword;
            }

            if(user.Password != password){
                return Errors.Authentication.IncorrectPassword;
            }
            var token = _jwtTokenGenerator.GenerateToken(user.UserId , user.FirstName , user.LastName , user.Email );
            return new AuthenticationResult(user.UserId, user.FirstName, user.LastName, email, token);
        }
    }
}