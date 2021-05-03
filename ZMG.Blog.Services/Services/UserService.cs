using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMG.Blog.Core.Interfaces.Services;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly ClientAppConfiguration _clientAppConfiguration;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager,
            IOptions<JwtConfiguration> jwtConfiguration,
            IOptions<ClientAppConfiguration> clientConfiguration,
            IMapper mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtConfiguration = jwtConfiguration?.Value ?? throw new ArgumentNullException(nameof(jwtConfiguration));
            _clientAppConfiguration = clientConfiguration?.Value ?? throw new ArgumentNullException(nameof(clientConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<User> LoginAsync(LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                return null;

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.NormalizedEmail == loginRequest.Email);

            // check if username exists
            if (user == null)
                return null;

            if(await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userDto = _mapper.Map<User>(user);
                userDto.Token = GenerateJWT(user, roles);
                userDto.Roles = roles.ToList();
                return userDto;
            }

            throw new BusinessException(INVALID_CREDENTIALS_ERROR_MESSAGE, ErrorCodes.InvalidCredentials);
        }
    }
}
