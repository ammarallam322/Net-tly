using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using teamProject.Models;

namespace teamProject.viewModel
{
    public class UserViewModel
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string Address { get; set; }


        [Required(ErrorMessage = "Role is required")] // Added
        public string SelectedRole { get; set; } // Added

        public List<string>? Roles { get; set; } // Changed to List<string>

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not match Confirm")]
        public string ConfirmPassword { get; set; }
    }

}
