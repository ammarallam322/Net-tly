using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public enum OfferStatus
    {
        Active,
        Expired,
        Canceled
    }
    public class Offer
    {   public int Id { get; set; }
        public string Name { get; set; }
        public int offerduration {  get; set; }
        public OfferStatus offerStatus { get; set; } = OfferStatus.Active;
        //nav ?? virtual??
        public virtual myServiceProvider? ServiceProvider { get; set; }
        [ForeignKey(nameof(ServiceProvider))]
        public int? Servuce_Id { get; set; }
    }
}
