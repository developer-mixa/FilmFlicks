using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FilmFlicks.Domain;
using FilmFlicks.Domain.Auth;
using FilmFlicks.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FilmFlicks.Infrastructure;

public class JwtProvider : IJwtProvider
{
    public string GenerateToken(User user)
    {
        Claim[] claims = [new Claim("userId", user.Id.ToString())];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Envs.GetSecurityKey())),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(Envs.GetExpireHours())
        );

        var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenStr;
    }
}