using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using teamProject.Models;

namespace teamProject.viewModel
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(40, ErrorMessage = "Name cannot exceed 40 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^0\d{7,9}$", ErrorMessage = "Phone number must be Valid With Government Code")]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "SSN is required")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "SSN must be exactly 14 digits")]
        public string SSN { get; set; }

        public int Service_Id { get; set; }
        public virtual SelectList? myServiceProviders { get; set; }

        public int Offer_Id { get; set; }
        public virtual SelectList? Offer_Services { get; set; }

        public int Central_Id { get; set; }
        public virtual SelectList? centrals { get; set; }

        public int Package_Id { get; set; }
        public virtual SelectList? packages { get; set; }
    }
}
