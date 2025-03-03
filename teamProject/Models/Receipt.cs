using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    public enum PaymentStatus
    {
        Unpaid = 0,     
        Paid = 1,        
        Deferred = 2     
    }
    public class Receipt
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Client))]
        public int Client_Id { get; set; }
        public DateOnly? Start_Date { get; set; }
        public DateOnly? End_Date { get; set; }
        public DateTime? Paid_Date { get; set; }
        public int Paid_Count { get; set; } 
        public PaymentStatus paymentStatus { get; set; }
        public double Total_Price { get; set; }
        public virtual myServiceProvider? ServiceProvider { get; set; }
        public virtual Client? Client { get; set; }
    }
}
