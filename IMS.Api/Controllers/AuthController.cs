using IMS.Core.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IMS.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public IActionResult GenerateToken()
        {
            var key = "ThisIsADevelopmentSecretKeyThatShouldBeLongEnough123!";

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, "EMP001"),
            new Claim(JwtRegisteredClaimNames.Name, "Pedro Aguirre"),
            new Claim("scope", Permissions.RoleRead)
        };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(
                signingKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "IMS",
                audience: "IMS.Api",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                accessToken
            });
        }

    }
}
