using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public class Governerate
    {
        public int Id { get; set; }
        [MinLength(3,ErrorMessage = "The number of characters must be greater than or equal to 3")]
        
        public string Name { get; set; }
        [MaxLength(4,ErrorMessage = "The number must be less than or equal to four")]
        public string Code { get; set; }

        //nav ??virtual?
        public virtual List<Central>? centrals { get; set; }

        //nav
        public virtual Branch? Branch { get; set; }

        [ForeignKey(nameof(Branch))]
        public int? Branch_Id { get; set; }





    }
}
