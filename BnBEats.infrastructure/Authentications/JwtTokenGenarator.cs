using System.Security.Claims;
using BnBEats.application;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace BnBEats.infrastructure;

public class JwtTokenGenarator : IJwtTokenGenerator
{


    public string GenerateToken(Guid userId, string firstName, string lastName, string email)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),
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
            audience: "BnBEats",
            issuer: "BnBEats",
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signingCredentials);
            

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
