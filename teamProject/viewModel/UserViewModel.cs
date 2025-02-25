using System.ComponentModel.DataAnnotations;

namespace teamProject.viewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public List<string> Roles { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not match Confirm")]
        public string ConfirmPassword { get; set; }


    }
}
