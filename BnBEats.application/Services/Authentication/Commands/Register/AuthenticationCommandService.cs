using BnBEats.application;
using BnBEats.application.Services.Authentication;
using BnBEats.domain;
using ErrorOr;

namespace BnBEata.application.Services.Authentication 
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository  _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator , IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;

        }

        public  ErrorOr<AuthenticationResult>  Register(string firstName, string lastName, string email, string password)
        {
            if( _userRepository.GetUserByEmail(email) is not null ){
                return Errors.Authentication.DuplicateEmail ;
            }

            User user = new User () {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.AddUser(user);

            var userId = user.UserId;

            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName, email);
            return new AuthenticationResult( userId,firstName, lastName,email,token);
        }

    }
}