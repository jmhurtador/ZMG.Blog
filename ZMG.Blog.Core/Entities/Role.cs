using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ZMG.Blog.Core.Entities
{
    [ExcludeFromCodeCoverage]
    public class Role : IdentityRole
    {
        public List<UserRole> UserRoles { get; set; }
    }
}