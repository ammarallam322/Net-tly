using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public class Governerate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters")]
        [MaxLength(8, ErrorMessage = "The name must be at most 8 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [MaxLength(4, ErrorMessage = "The code must be at most 4 characters")]
        public string Code { get; set; }

        //nav ??virtual?
        public virtual List<Central>? centrals { get; set; }

        //nav
        public virtual Branch? Branch { get; set; }

        [ForeignKey(nameof(Branch))]
        public int? Branch_Id { get; set; }





    }
}
