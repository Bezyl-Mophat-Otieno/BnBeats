namespace BnBEats.contracts.Authentications
{
    public record RegisterRequest(string FirstName, string LastName, string Email, string Password);
}