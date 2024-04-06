using BnBEats.application;
using BnBEats.application.Services.Authentication;
using BnBEats.domain;

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

        public  AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // if( _userRepository.GetUserByEmail(email) is not null ){
                
                throw new BadRequestException("User already exists");
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

        public AuthenticationResult Login(string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) is not User user){
                throw new NotFoundException("User Not Found");
            }

            if(user.Password != password){
                throw new BadRequestException("Incorrect Password");
            }
            var token = _jwtTokenGenerator.GenerateToken(user.UserId , user.FirstName , user.LastName , user.Email );
            return new AuthenticationResult(user.UserId, user.FirstName, user.LastName, email, token);
        }
    }
}