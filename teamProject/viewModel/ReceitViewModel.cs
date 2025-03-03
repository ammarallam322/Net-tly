using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;

namespace teamProject.viewModel
{
    public class ReceitViewModel
    {

        public int Client_Id { get; set; }
        public string Name { get; set; } 
        public string Address { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string? ServiceProviderName { get; set; }
        public string PackageName { get; set; }
        public double Package_Price { get; set; }
        public string OfferName { get; set; }
        public string offerStatus { get; set; }
        public double Total_Price { get; set; }
        public DateOnly? Start_Date { get; set; }
        public DateOnly? End_Date { get; set; }
        public DateTime? Paid_Date { get; set; }
        public int Paid_Count { get; set; }

        //public PaymentStatus? paymentStatus { get; set; }
        public SelectList? clients { get; set; }
       
    }
}
