using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infra.Auth;

public class AuthService(IConfiguration configuration) : IAuthService
{
    private readonly IConfiguration _configuration = configuration;

    public string ComputeHash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    public string GenerateToken(string email, string role)
    {
        string jwtKey = _configuration["Jwt:Key"];
        string issuer = _configuration["Jwt:Issuer"];
        string audience = _configuration["Jwt:Audience"];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("username", email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(issuer: issuer, audience: audience, claims: claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);

        var handler = new JwtSecurityTokenHandler();

        return handler.WriteToken(token);
    }
}
