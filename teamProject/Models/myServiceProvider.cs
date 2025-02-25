using System.Text.Json.Serialization;

namespace teamProject.Models
{
    public class myServiceProvider
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public bool Active { get; set; }

        //nav ?virtual?
        public virtual List<Offer>? Offers { get; set; }


        //nav ?virtual?
        [JsonIgnore]
        public virtual List<Provider_Package>? Provider_Packages { get; set; }

        // [Added by Mohab 22-2]
        public virtual List<Client>? Clients { get; set;  }
    }
}
