using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZMG.Blog.Core.Interfaces.Services;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
        IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Validates user credentials and generates a JWT for authorization
        /// </summary>
        /// <param name="loginRequest">Login Request</param>
        /// <returns>User with the authorization token</returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var userDto = await _userService.LoginAsync(loginRequest);
                if (userDto == null)
                    return BadRequest(new { message = "Username or password is incorrect." });
                return Ok(userDto);
            }
            return BadRequest(new { message = "Invalid request." });
        }
    }
}
