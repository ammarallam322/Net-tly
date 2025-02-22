using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace teamProject.viewModel.Branch
{
    public class BranchPhMobViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Fax { get; set; }
        [MaxLength(11)]
        public string? Mobile1 { get; set; }
        [MaxLength(11)]
        public string? Mobile2 { get; set; }
        [MaxLength(25)]
        public string? Phone1 { get; set; }
        [MaxLength(25)]
        public string? Phone2 { get; set; }
        [Display(Name = "Manager")]
        [ForeignKey("Manager")]
        public string ManagerName { get; set; }
        public virtual List<IdentityUser> Users { get; } = new List<IdentityUser>();
    }
}
