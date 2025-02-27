using AutoMapper;
using teamProject.Models;
using teamProject.viewModel;

namespace teamProject.MapConfig
{
    public class PackageConfig :Profile
    {
        public PackageConfig()
        {
                CreateMap<package, PackagesViewModel>().AfterMap((src, dist) => { }).ReverseMap();

        }


    }
}
