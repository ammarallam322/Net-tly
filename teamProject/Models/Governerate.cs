using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public class Governerate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        //nav ??virtual?
        public virtual List<Central> centrals { get; set; }

        //nav
        public virtual Branch Branch { get; set; }

        [ForeignKey(nameof(Branch))]
        public int Branch_Id { get; set; }





    }
}
