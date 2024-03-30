using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace COMP1640.Repositories.Services.AuthService
{
    public class AuthService : IAuthRepository
    {
        public async Task<object> CheckRole(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);

            // Access claims or other properties
            var userId = jsonToken.Claims.FirstOrDefault(c => c.Type == "usid")?.Value;
            var userRole = jsonToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
            return new
            {
                id = userId,
                role = userRole,
            };
        }

        public string GenerateCookieToken(User user, IHttpContextAccessor _httpContextAccessor)
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my secret key a ah"));
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            Console.WriteLine(user.Role);
            var claims = new List<Claim>
                {
                    new Claim("usid", user.Id.ToString()),
                    new Claim("falcutyId", user.FalcutyId.ToString()),
                    new Claim("role", user.Role),
                    new Claim(ClaimTypes.Role, user.Role)
                };

            var tokenOptions = new JwtSecurityToken(
                issuer: "Issue Here",
                audience: "Audiencce Here",
                claims: claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }

        public string GenerateCookieTokenForSelectedRole(User user, string selectedRole)
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my secret key a ah"));
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            Console.WriteLine(user.Role);
            var claims = new List<Claim>
                {
                    new Claim("usid", user.Id.ToString()),
                    new Claim("falcutyId", user.FalcutyId.ToString()),
                    new Claim("role", selectedRole),
                    new Claim(ClaimTypes.Role, selectedRole)
                };

            var tokenOptions = new JwtSecurityToken(
                issuer: "Issue Here",
                audience: "Audiencce Here",
                claims: claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
