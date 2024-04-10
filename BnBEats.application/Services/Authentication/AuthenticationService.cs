using BnBEats.application;
using BnBEats.application.Services.Authentication;
using BnBEats.domain;
using ErrorOr;

namespace BnBEata.application.Services.Authentication 
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository  _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator , IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;

        }

        public  ErrorOr<AuthenticationResult>  Register(string firstName, string lastName, string email, string password)
        {
            // if( _userRepository.GetUserByEmail(email) is not null ){
                return Errors.Authentication.DuplicateEmail ;
            // }

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