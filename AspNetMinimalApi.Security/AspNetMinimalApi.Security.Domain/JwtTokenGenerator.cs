using AspNetMinimalApi.Security.Domain.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetMinimalApi.Security.Domain;

internal class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateTokenAsync(string username)
    {
        return GenerateTokenWithClaims(username);
    }

    private static string GenerateTokenWithClaims(string username)
    {
        const string superSecretKey = "super_secret_key_with_numbers_123987";

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(superSecretKey));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        var expiry = DateTime.UtcNow.AddDays(1);
        var claims = GetClaimsForLoginAsync(username);

        var securityToken = new JwtSecurityToken(
            "https://localhost/",
            "https://localhost/",
            claims,
            expires: expiry,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);

        static IEnumerable<Claim> GetClaimsForLoginAsync(string username)
        {
            List<Claim> claimsList = new()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "secretRole")
            };

            return claimsList;
        }
    }
}
