using ErrorOr;

namespace BnBEats.application.Services.Authentication
{
    public interface IAuthenticationCommandService
    {
        public ErrorOr<AuthenticationResult> Register( string firstName, string lastName, string email, string password );
    }
}