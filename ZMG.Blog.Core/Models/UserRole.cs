using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace ZMG.Blog.Core.Models
{
    [ExcludeFromCodeCoverage]
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
