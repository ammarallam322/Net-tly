using teamProject.Models;

namespace teamProject.viewModel
{
    public class PackagesViewModel
    {

        public string Name { get; set; }
        public string Type { get; set; }

        public string Notes { get; set; }


        public bool Active { get; set; }

        public int Price { get; set; }


        //nav ?? virtual??
        //nav ?virtual?

        public virtual List<Provider_Package>? Provider_Packages { get; set; }
    }
}
