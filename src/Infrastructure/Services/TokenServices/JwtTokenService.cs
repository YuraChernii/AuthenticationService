using Domain.Services;
using Infrastructure.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.TokenServices
{
    internal class JwtTokenService : ITokenService
    {
        private readonly JwtTokenOptions jwtTokenOptions;

        public JwtTokenService(IOptions<JwtTokenOptions> jwtTokenConfigs)
        {
            this.jwtTokenOptions = jwtTokenConfigs.Value;
        }

        public string GenerateToken(string username)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(jwtTokenOptions.SecretKey);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new([new(ClaimTypes.Name, username)]),
                Issuer = jwtTokenOptions.Issuer,
                Audience = jwtTokenOptions.Audience,
                Expires = DateTime.UtcNow.AddMinutes(jwtTokenOptions.ExpirationInMinutes),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}