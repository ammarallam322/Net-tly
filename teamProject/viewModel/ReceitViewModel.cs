using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;

namespace teamProject.viewModel
{
    public class ReceitViewModel
    {
       
        //public DateOnly? Start_Date { get; set; }
        //public DateOnly? End_Date { get; set; }
        //public DateTime? Paid_Date { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; } 

        public string Mobile { get; set; }

        public string OfferName { get; set; }
        public string PackageName { get; set; }
        public int Package_Price { get; set; }
        //public PaymentStatus? paymentStatus { get; set; }
        public double Total_Price { get; set; }
        public string? ServiceProviderName { get; set; }

        public SelectList? clients { get; set; }
        public int Client_Id { get; set; }
       
    }
}
