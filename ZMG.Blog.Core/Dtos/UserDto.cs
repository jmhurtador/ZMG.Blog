using System;
using System.Collections.Generic;

namespace ZMG.Blog.Core.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
