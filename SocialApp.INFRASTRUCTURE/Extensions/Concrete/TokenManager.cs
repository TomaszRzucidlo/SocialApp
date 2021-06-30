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

        public string GenerateToken(Guid userId, string email)
        {
            DateTime now = DateTime.UtcNow;
            var clims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
            var token = new JwtSecurityToken(
                issuer: settings.Issuer,
                audience: settings.Issuer,
                claims: clims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenAsString;
        }
    }
}
