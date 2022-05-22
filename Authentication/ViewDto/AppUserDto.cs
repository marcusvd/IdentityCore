

using Microsoft.AspNetCore.Identity;

namespace Authentication.ViewDto
{
    public class AppUserDto : IdentityUser
    {
        public string FullName { get; set; }
        public string OrgId { get; set; }
    }
    public class OrganizationDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}