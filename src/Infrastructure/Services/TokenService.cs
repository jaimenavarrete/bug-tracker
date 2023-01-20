using Application.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AuthOptions> _authOptions;

        public TokenService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions;
        }

        public string GenerateToken(User user)
        {
            // Header
            var secretKeyBytes = Encoding.UTF8.GetBytes(_authOptions.Value.SecretKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(secretKeyBytes);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            // Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            // Payload
            var payload = new JwtPayload(
                _authOptions.Value.Issuer,
                _authOptions.Value.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(5)
                );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
