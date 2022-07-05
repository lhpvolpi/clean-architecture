using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Helpers
{
    public static class JwtExtensions
    {
        public static string NameId => "nameid";

        public static string Email => "email";

        public static string? GetClaimByType(this string token, string type) =>
            new JwtSecurityTokenHandler().ReadJwtToken(token)?.Claims.FirstOrDefault(i => i.Type == type)?.Value;
    }
}