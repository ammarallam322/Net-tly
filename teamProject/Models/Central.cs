using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public class Central
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //nav ?virtual?
        public virtual Governerate Governerate { get; set; }

        [ForeignKey(nameof(Governerate))]
        public int? Gov_Id { get; set; }


    }
}
