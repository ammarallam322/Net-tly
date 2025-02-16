using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public string Name { get; set; }


        //nav ?? virtual??
        public virtual ServiceProviderRepository ServiceProvider { get; set; }
        [ForeignKey(nameof(ServiceProvider))]
        public int Servuce_Id { get; set; }

    }
}
