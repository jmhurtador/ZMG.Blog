using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZMG.Blog.Core.Dtos;
using ZMG.Blog.Core.Entities;
using ZMG.Blog.Core.Interfaces.Services;
using ZMG.Blog.Core.Models;
using ZMG.Blog.Core.Models.Configurations;

namespace ZMG.Blog.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,
            IOptions<JwtConfiguration> jwtConfiguration,
            IMapper mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtConfiguration = jwtConfiguration?.Value ?? throw new ArgumentNullException(nameof(jwtConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<UserDto> LoginAsync(LoginRequest loginRequest)
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
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = GenerateJWT(user, roles);
                userDto.Roles = roles.ToList();
                return userDto;
            }

            return null;
        }

        /// <summary>
        /// Generates a JSON Web Token for the client to use
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="roles">User role list</param>
        /// <returns>JSON Web Token</returns>
        private string GenerateJWT(User user, IList<string> roles)
        {
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

            var tokenClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            };
            tokenClaims.AddRange(roleClaims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes(_jwtConfiguration.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(tokenClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
