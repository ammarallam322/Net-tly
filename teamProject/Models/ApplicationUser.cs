using Microsoft.AspNetCore.Identity;

namespace teamProject.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string? Address { get; set; }
    }
}
