using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(
        IUserService userService,
        IMapper mapper,
         Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = config;
        }

        /// <summary>
        /// Validates user credentials and generates a JWT for authorization
        /// </summary>
        /// <param name="loginRequest">Registration Request</param>
        /// <returns>User created and the authorization token</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.LoginAsync(loginRequest);
                return Ok(user);
            }
            return BadRequest(new ErrorResponse
            {
                ErrorMessage = "Invalid Credentials.",
                ErrorCode = ErrorCodes.InvalidCredentials
            });
        }
    }
}
