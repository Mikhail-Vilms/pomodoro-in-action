using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PomodoroInAction.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public AppUsersController(UserManager<AppUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AppUserModel model)
        {
            AppUser applicationUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Email is not found" });
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return BadRequest(new { message = "Password is incorrect" });
            }

            return Ok( new { Token = this.GenerateToken(user) } );
        }

        private string GenerateToken(AppUser user)
        {
            // SecurityTokenDescriptor: Contains some information which used to create a security token.
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = GetSigninCredentials(),
                // Inside subject we need to put claims associated with the user
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("UserID", user.Id.ToString())
                }),
                Issuer = _appSettings.JWT_Issuer
            };

            // A SecurityTokenHandler designed for creating and validating JWTs.
            JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

            // Generate jwt token
            SecurityToken securityToken = _tokenHandler.CreateToken(tokenDescriptor);

            // Serialize toket to "Compact Serialization Format"
            return _tokenHandler.WriteToken(securityToken);
        }

        private SigningCredentials GetSigninCredentials()
        {
            // security key from safe vault
            string _securityKey = _appSettings.JWT_Secret;

            // symmetric key generated based on security key
            // #TODO why exactly do we need this? GOOGLE IT
            SymmetricSecurityKey _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));

            // SigningCredentials: Represents the cryptographic key and security algorithms that are used to generate a digital signature.
            SigningCredentials _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            return _signingCredentials;
        }
    }
}