using System.Security.Claims;
using BnBEats.application;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;


namespace BnBEats.infrastructure;

public class JwtTokenGenarator : IJwtTokenGenerator
{

   private readonly JwtSettings _jwtSettings;

    public JwtTokenGenarator(IOptions<JwtSettings> jwtOptionsSettings)
    {
        _jwtSettings = jwtOptionsSettings.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName, string email)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.Email, email),
        };

        var token = new JwtSecurityToken(
            claims: claims,
            audience: _jwtSettings.Audience,
            issuer: _jwtSettings.Issuer,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signingCredentials);
            

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
