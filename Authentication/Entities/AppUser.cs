

using Microsoft.AspNetCore.Identity;

namespace Authentication.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string OrgId { get; set; }
    }
    public class Organization
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}