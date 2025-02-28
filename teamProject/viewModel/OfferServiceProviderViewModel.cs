using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using teamProject.Models;

namespace teamProject.viewModel
{
    public class OfferServiceProviderViewModel
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public int OfferDuration { get; set; }
        public int? ServiceProviderId { get; set; }
        public string? ServiceProviderName { get; set; }
        public IEnumerable<SelectListItem>? ServiceProviders { get; set; }
    }
}
