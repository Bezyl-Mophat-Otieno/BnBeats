namespace BnBEats.application;

public interface IJwtTokenGenerator
{
    public string GenerateToken(Guid userId , string firstName , string lastName, string email);

}
