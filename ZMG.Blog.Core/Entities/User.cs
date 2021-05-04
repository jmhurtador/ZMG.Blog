using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace ZMG.Blog.Core.Entities
{
    /// <summary>
    /// Class to extend the default IdentityUser properties with custom properties we need for our users.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserRole> UserRoles { get; set;} = new List<UserRole>();

        [NotMapped]
        public List<string> Roles {
            get { return UserRoles.Select(r => r.Role.Name).ToList();}
        }
    }
}
