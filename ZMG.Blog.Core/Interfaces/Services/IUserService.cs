using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> LoginAsync(LoginRequest loginRequest);
    }
}
