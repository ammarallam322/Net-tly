using AutoMapper;
using teamProject.Models;
using teamProject.viewModel.Branch;

namespace teamProject.MapConfig
{
    public class BranchConfig : Profile
    {
        public BranchConfig()
        {
            CreateMap<Branch, BranchPhMobViewModel>().AfterMap((src, dest) =>
            {
                dest.Mobile1 = src.BranchMobiles?.Br_Mob1;
                dest.Mobile2 = src.BranchMobiles?.Br_Mob2;
                dest.Phone1 = src.BranchPhones?.Br_Ph1;
                dest.Phone2 = src.BranchPhones?.Br_Ph2;
                dest.ManagerName = src.Manager?.UserName;
            }).ReverseMap();
            
            CreateMap<Branch, BranchEditViewModel>().AfterMap((src, dest) =>
            {
                dest.Mobile1 = src.BranchMobiles?.Br_Mob1;
                dest.Mobile2 = src.BranchMobiles?.Br_Mob2;
                dest.Phone1 = src.BranchPhones?.Br_Ph1;
                dest.Phone2 = src.BranchPhones?.Br_Ph2;
            }).ReverseMap();

            CreateMap<Branch, BranchForCreateViewModel>().ReverseMap();
        }
    }
}
