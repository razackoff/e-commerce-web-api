using Market.Auth.Common;
using Market.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Market.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> authOptions;

        public AuthController(IOptions<AuthOptions> authOptions)  
        {
            this.authOptions = authOptions;
        }

        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = Guid.Parse("dc59afce-abe3-4b90-ae6e-554e9e6bf2fb"),
                Email = "user1@gmail.com",
                Password = "user1",
                Role = role.User
            },
            new Account()
            {
                Id = Guid.Parse("1a1fa45f-2ec7-4333-8d4c-82351b5cecd5"),
                Email = "user2@gmail.com",
                Password = "user2",
                Role = role.User
            },
            new Account()
            {
                Id = Guid.Parse("d09d68d9-69e1-4e72-a5d0-aa62c890ca3f"),
                Email = "admin@gmail.com",
                Password = "admin",
                Role = role.Admin
            }
        };

        [Route("LogIn")]
        [HttpPost]
        public IActionResult Login([FromBody]Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            
            if(user != null)
            {
                var token = GenerateJWT(user);

                return Ok(new
                {
                    acces_token = token
                });
            }

            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            return Accounts.SingleOrDefault(u => 
                 u.Email == email && u.Password == password);
        }

         private string GenerateJWT(Account user)
        {
            var authParam = authOptions.Value;

            var securityKey = authParam.GetSymmetricSecuriteKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("role", user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                authParam.Issuer,
                authParam.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParam.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
