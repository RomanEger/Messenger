using System.Security.Claims;
using Application.DataTransferObjects;

namespace Application.Services.Contracts;

public interface ITokenService
{
    AccessTokenDto GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}