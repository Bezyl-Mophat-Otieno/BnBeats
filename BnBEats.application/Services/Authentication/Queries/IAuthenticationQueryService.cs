using ErrorOr;

namespace BnBEats.application.Services.Authentication
{
    public interface IAuthenticationQueryService
    {
        public ErrorOr<AuthenticationResult>  Login( string email, string password);
    }
}