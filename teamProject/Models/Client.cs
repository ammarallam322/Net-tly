using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } //?name is existed in user table

        public string Mobile { get; set; }///???has more than one mobile number
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }

        [ForeignKey(nameof(ServiceProvider))]
        public int Service_Id { get; set; }
        public virtual myServiceProvider? ServiceProvider { get; set; }

        [ForeignKey(nameof(Offer))]
        public int Offer_Id { get; set; }
        public virtual Offer Offer { get; set; }


        [ForeignKey(nameof(Central))]
        public int Central_Id { get; set; }
        public virtual Central Central { get; set; }

        //nav
        public virtual package package { get; set; }
        [ForeignKey(nameof(package))]
        public int? Package_Id { get; set; }


        //f.k??
        public int User_Id { get; set; }
    }
}
