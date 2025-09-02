using Housing_Society.Buisness_Logic.IServices;

using Housing_Society.Models;
using Housing_Society.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Housing_Society.Buisness_Logic
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<string> GenerateToken(LoginRequestDto user)
        {
            string role = user.username.ToLower() switch
            {
                "admin" => "Admin",
                _ => "User"
            };
            

            var claims =  new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.username),
            new Claim("id", user.id.ToString() ?? string.Empty),
            new Claim("role", role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token =  new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

             return   new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
