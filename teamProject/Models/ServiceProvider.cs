namespace teamProject.Models
{
    public class ServiceProviderRepository
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public bool Active { get; set; }

        //nav ?virtual?
        public virtual List<Offer> Offers { get; set; }


        //nav ?virtual?

        public virtual List<Provider_Package> Provider_Packages { get; set; }

    }
}
