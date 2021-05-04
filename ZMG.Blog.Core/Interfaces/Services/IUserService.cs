using System.Threading.Tasks;
using ZMG.Blog.Core.Dtos;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> LoginAsync(LoginRequest loginRequest);
    }
}
