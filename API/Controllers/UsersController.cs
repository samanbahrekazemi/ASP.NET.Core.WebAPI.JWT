using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsersForAdminAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }
    }
}
