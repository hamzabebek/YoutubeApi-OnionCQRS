using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Interface.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);

        string GenerateRefreshToken();

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
