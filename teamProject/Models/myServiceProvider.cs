using System.Text.Json.Serialization;

namespace teamProject.Models
{
    public class myServiceProvider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }
        public virtual List<Offer>? Offers { get; set; }

        [JsonIgnore]
        public virtual List<Provider_Package>? Provider_Packages { get; set; }
        public virtual List<Client>? Clients { get; set;  }
    }
}
