

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Entities
{
    public class UserRole: IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }

    }

}