using Domain.Services;
using Infrastructure.Models.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.TokenServices
{
    internal class JwtTokenService : ITokenService
    {
        private readonly JwtTokenConfigs jwtTokenConfigs;

        public JwtTokenService(IOptions<JwtTokenConfigs> jwtTokenConfigs)
        {
            this.jwtTokenConfigs = jwtTokenConfigs.Value;
        }

        public string GenerateToken(string username)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(jwtTokenConfigs.SecretKey);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new([new(ClaimTypes.Name, username)]),
                Issuer = jwtTokenConfigs.Issuer,
                Audience = jwtTokenConfigs.Audience,
                Expires = DateTime.UtcNow.AddMinutes(jwtTokenConfigs.ExpirationInMinutes),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}