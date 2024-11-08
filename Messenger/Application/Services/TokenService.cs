using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.DataTransferObjects;
using Application.Services.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static Infrastructure.TokenConstants;

namespace Application.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;
    
    public TokenService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    
    public AccessTokenDto GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(AccessTokenExpiresHour),
            signingCredentials);

        var accessToken = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return new AccessTokenDto(accessToken, AccessTokenExpiresHour * SecondsInHour);
    }
    
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        
        using var rng = RandomNumberGenerator.Create();
        
        rng.GetBytes(randomNumber);
        
        return Convert.ToBase64String(randomNumber);
    }
    
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, 
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            ValidateLifetime = false
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        
        if (securityToken is not JwtSecurityToken jwtSecurityToken 
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        
        return principal;
    }
}