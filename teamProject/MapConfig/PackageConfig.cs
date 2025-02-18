using AutoMapper;
using teamProject.Models;
using teamProject.viewModel;

namespace teamProject.MapConfig
{
    public class PackageConfig :Profile
    {
        //ref from my context
        TeamContext context = new TeamContext();



        public PackageConfig()
        {
            CreateMap<package, PackagesViewModel>().AfterMap((src, dist) => { }).ReverseMap();
        }
    }
}
