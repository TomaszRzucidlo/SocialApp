using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialApp.DB.Settings;
using SocialApp.INFRASTRUCTURE.DTOs;
using SocialApp.INFRASTRUCTURE.Extensions.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Extensions.Concrete
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtSettings settings;
        public TokenManager(IOptions<JwtSettings> options)
        {
            this.settings = options.Value;
        }

        public TokenDTO GenerateToken(Guid userId, string email)
        {
            DateTime now = DateTime.UtcNow;
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
            };

            var tokenExpirationMins = now.AddMinutes(settings.ExpiresMinutes);
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
            var token = new JwtSecurityToken(
                issuer: settings.Issuer,
                claims: claims, notBefore: now,
                expires: tokenExpirationMins,
                signingCredentials: new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256));
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDTO(encodedToken, email);
        }
    }
}
