using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions; 
    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;        
    }

    public string CreateToken(User user)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim("NameLastName", user.NameLastName)
        };

        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwtOptions.Issuer,
            auidence: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256
            ));

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token;
    }
}
