using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Service;

public class TokenService
{

    
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<string> GerarToken(ApplicationUser usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Name),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims, 
            expires: DateTime.Now.AddMinutes(30), 
            signingCredentials: credentials,
            issuer: "ServiceHub.Api",
            audience: "ServiceHub.Api"
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}