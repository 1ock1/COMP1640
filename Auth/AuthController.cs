using Azure;
using Azure.Core;
using COMP1640.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace COMP1640.Auth
{
    public static class AuthController
    {
        public static bool GenerateCookieToken(UserDTO user, IHttpContextAccessor _httpContextAccessor)
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my secret key a ah"));
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("usid", user.Email),
                new Claim("role", user.Password),
                //new Claim(ClaimTypes.Role, result.Role)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "Issue Here",
                audience: "Audiencce Here",
                claims: claims,
                //expires: DateTime.Now.AddSeconds(5),
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var options = new CookieOptions
            {
                //Expires = DateTime.Now.AddSeconds(5),
                Secure = true, // Set to true if using HTTPS
                HttpOnly = true, // Set HttpOnly flag
                SameSite = SameSiteMode.Strict // Set SameSite attribute
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("us", token, options);
            return true;
        }
    }
}
