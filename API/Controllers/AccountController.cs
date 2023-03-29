using API.Helpers;
using API.Settings;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Presentation.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        public AccountController(IOptions<JwtSettings> jwtSettings,  UserManager<User> userManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                foreach (var userRole in userRoles)
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                var token = JwtHelper.GetJwtToken(
                    model.UserName,
                    _jwtSettings.Key,
                    _jwtSettings.Issuer,
                    _jwtSettings.Audience,
                    TimeSpan.FromDays(_jwtSettings.ExpireDays),
                    authClaims.ToArray());

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expires = token.ValidTo
                });
            }
            return Unauthorized();
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Succeeded = false, Message = "User already exists!" });

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Succeeded = false, Message = result.Errors.FirstOrDefault()?.Description ?? "User creation failed! Please check user details and try again." });

            return Ok(new Result(true) { Message = "User created successfully!" });
        }

    }
}
