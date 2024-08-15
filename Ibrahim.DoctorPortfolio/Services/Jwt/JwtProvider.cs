using Ibrahim.DoctorPortfolio.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ibrahim.DoctorPortfolio.Services.Jwt
{
    public class JwtProvider: IJwtProvider
    {
        private readonly JwtSettings _settings;

        public JwtProvider(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;            
        }

        public string Create(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: ExtractUserClaims(user),
                expires: DateTime.UtcNow.AddDays(_settings.ExpirationInDays),
                signingCredentials: credentials);
          
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> ExtractUserClaims(IdentityUser user)
            => new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };
    }
}
