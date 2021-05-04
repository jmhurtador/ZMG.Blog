using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace ZMG.Blog.Core.Entities
{
    [ExcludeFromCodeCoverage]
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
