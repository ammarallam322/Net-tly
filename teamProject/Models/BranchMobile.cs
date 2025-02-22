using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace teamProject.Models
{
    public class BranchMobile
    {
        public int Id { get; set; }
        [ForeignKey("branch")]
        public int Br_Id { get; set; }
        [Display(Name = "Mobile1")]
        [MaxLength(11, ErrorMessage = "Moblie must equal 11 number")]
        public string? Br_Mob1 { get; set; }
        [Display(Name = "Mobile2")]
        [MaxLength(11, ErrorMessage = "Moblie must equal 11 number")]
        public string? Br_Mob2 { get; set; }
        public virtual Branch? branch { get; set; }
    }
}
