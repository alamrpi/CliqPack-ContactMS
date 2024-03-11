using Microsoft.AspNetCore.Identity;

namespace ContactMS.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
