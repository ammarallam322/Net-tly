using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace teamProject.Models
{
    public class BranchPhone
    {
        public int Id { get; set; }
        [ForeignKey("branch")]
        public int Br_Id { get; set; }
        [Display(Name = "Phone1")]
        [MaxLength(25)]
        public string? Br_Ph1 { get; set; }
        [Display(Name = "Phone2")]
        [MaxLength(25)]
        public string? Br_Ph2 { get; set; }
        public virtual Branch? branch { get; set; }
    }
}
