using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AuthService.Model.Configuration;
using AuthService.Model.Interfaces.Service;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Service.Service;

public class TokenService(IOptions<SecretKeys> options) : ITokenService
{
    private readonly SymmetricSecurityKey _secretKey = 
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Value.TokenSecretKey));
    public string GenerateToken(string email)
    {
        var claims = new[]
        {
            new Claim("Username", email)
        };

        var creds = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: "AuthSerivce",
            audience: "WebBackend",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}