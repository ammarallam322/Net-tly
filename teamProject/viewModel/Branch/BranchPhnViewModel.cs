using System.ComponentModel.DataAnnotations;

namespace teamProject.viewModel.Branch
{
    public class BranchPhnViewModel
    {
        public int Br_Id { get; set; }
        [Display(Name = "Mobile1")]
        [MaxLength(11, ErrorMessage = "Moblie must equal 11 number")]
        public string? Br_Phn1 { get; set; }
        [Display(Name = "Mobile2")]
        [MaxLength(11, ErrorMessage = "Moblie must equal 11 number")]
        public string? Br_Phn2 { get; set; }
    }
}
