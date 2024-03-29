namespace BnBEats.contracts.Authentications;

   public record AuthResponse(Guid Id,
       string FirstName,
       string LastName,
       string Email,
       string Token);
