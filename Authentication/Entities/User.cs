

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Entities
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Member {get; set;}
        public string OrgId { get; set; }
        public List<UserRole> UserRoles {get; set;}
    }
  
}