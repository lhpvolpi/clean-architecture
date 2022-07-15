using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Services;
using CleanArchitecture.Core.ValueObjects;
using CleanArchitecture.Infrastructure.Common;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IJwtSettings _jwtSettings;

        public JwtService(IJwtSettings jwtSettings) => this._jwtSettings = jwtSettings;

        public TokenVO GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(this._jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = this._jwtSettings.Audience,
                Issuer = this._jwtSettings.Issuer,
                IssuedAt = DateTime.UtcNow,
                Subject = new ClaimsIdentity(new[]
                {
                   new Claim(type: ClaimTypes.NameIdentifier, value: user.Id.ToString()),
                   new Claim(type: ClaimTypes.Email,value: user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(this._jwtSettings.ExpiresInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenVO(tokenHandler.WriteToken(securityToken), tokenDescriptor.IssuedAt.Value, tokenDescriptor.Expires.Value);
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token), "is required");

            var key = Encoding.ASCII.GetBytes(this._jwtSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var validatedToken = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = true,
                ValidAudience = this._jwtSettings.Audience,
                ValidateIssuer = true,
                ValidIssuer = this._jwtSettings.Issuer,
                ClockSkew = TimeSpan.Zero
            });

            return validatedToken.IsValid;
        }
    }
}

