using System.ComponentModel.DataAnnotations;
using teamProject.Models;

namespace teamProject.viewModel.Branch
{
    public class BranchForCreateViewModel
    {
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
        public string? Manager_Id { get; set; }
        public List<ApplicationUser>? Employees { get; set; }
    }
}
