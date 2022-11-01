using Market.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Market.Security.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JWTSettings _options;

        public AuthorizeController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, IOptions<JWTSettings> optAccess)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _options = optAccess.Value;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(OtherParamUser paramUser)
        {
            var user = new IdentityUser { 
                PhoneNumber = paramUser.PhoneNumber, 
                Email = paramUser.Email
            };

            var result = await _userManager.CreateAsync(user, paramUser.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("FirstName", paramUser.FirstName));
                claims.Add(new Claim("SecondName", paramUser.SecondName));
                claims.Add(new Claim(ClaimTypes.DateOfBirth, paramUser.DateOfBith.ToString()));
                claims.Add(new Claim("Region", paramUser.Region));
                claims.Add(new Claim("Locality", paramUser.Locality));
                claims.Add(new Claim(ClaimTypes.Gender, paramUser.Gender.ToString()));
                claims.Add(new Claim("CreationDate", DateTime.UtcNow.ToString()));
                claims.Add(new Claim("EditDate", DateTime.UtcNow.ToString()));
                
                await _userManager.AddClaimsAsync(user, claims);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        private string GetToken(IdentityUser user, IEnumerable<Claim> prinicpal)
        {
            var claims = prinicpal.ToList();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        [HttpPost("SignIn")]
        public async  Task<IActionResult> SignIn(ParamUser paramUser)
        {
            var user = await _userManager.FindByEmailAsync(paramUser.Email);

            var result = await _signInManager.PasswordSignInAsync(user, paramUser.Password, false, false);

            if(result.Succeeded)
            {
                IEnumerable<Claim> claims = await _userManager.GetClaimsAsync(user);
                var token = GetToken(user, claims); 

                return Ok(token);
            }

            return BadRequest();
        }
    }
}
