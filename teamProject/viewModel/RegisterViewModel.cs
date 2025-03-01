using System.ComponentModel.DataAnnotations;

namespace teamProject.viewModel
{
    public class RegisterViewModel
    {

        public int Id { get; set; }
        //adding email property

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not match Confirm")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }


    }
}
