using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CS.Auth.Application.Configurations;
using CS.Auth.Application.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CS.Auth.Infrastructure.Implementation;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtTokenOption _jwtTokenOption;

    public JwtTokenGenerator(IOptions<JwtTokenOption> tokenOptionConfiguration)
    {
        _jwtTokenOption = tokenOptionConfiguration.Value;
    }

    public string GenerateTokenAsync(string userId, string[] roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userId),
            new Claim(ClaimTypes.Role, string.Join(",", roles))
        };
        var signingKey = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOption.Key)),
            SecurityAlgorithms.HmacSha512Signature
        );
        var token = new JwtSecurityToken(
            "issuer",
            "audience",
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingKey
        );
        var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return generatedToken;
    }
}