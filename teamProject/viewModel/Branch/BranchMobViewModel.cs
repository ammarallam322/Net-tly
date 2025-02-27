using System.ComponentModel.DataAnnotations;

namespace teamProject.viewModel.Branch
{
    public class BranchMobViewModel
    {
        public int Br_Id { get; set; }
        [Display(Name = "Mobile1")]
        [MaxLength(11, ErrorMessage = "Moblie must equal 11 number")]
        public string? Br_Mob1 { get; set; }
        [Display(Name = "Mobile2")]
        [MaxLength(11, ErrorMessage = "Moblie must equal 11 number")]
        public string? Br_Mob2 { get; set; }
    }
}
