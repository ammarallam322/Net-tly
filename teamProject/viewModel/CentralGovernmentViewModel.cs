using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace teamProject.viewModel
{
    public class CentralGovernmentViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Government")]
        public int? Gov_Id { get; set; } 
        public string GovernerateName { get; set; }
        public IEnumerable<SelectListItem>? Governerates { get; set; }
    }
}
