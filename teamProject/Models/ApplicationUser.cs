using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string? Address { get; set; }

        public virtual List<Branch>? ManagedBranches { get; set; } = new List<Branch>();

        [ForeignKey("Branch")]
        public int? BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
    }
}
