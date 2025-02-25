using AutoMapper;
using Microsoft.AspNetCore.Identity;
using teamProject.Models;
using teamProject.viewModel;

namespace teamProject.MapConfig
{
    public class UserConfig :Profile
    {

        public UserConfig()
        {
            //    CreateMap<ApplicationUser, UserViewModel>().AfterMap((src, dst) => {

            //        dst.Id = src.Id;
            //        dst.Address = src.Address;
            //        dst.Email = src.Email;
            //        dst.Name = src.UserName;
            //        dst.Password = src.PasswordHash;



            //    }).ReverseMap();



            //  CreateMap<ApplicationUser, UserViewModel>()
            //.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
            //.ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.UserName))
            //.ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.PasswordHash))
            //.ReverseMap();




            CreateMap<UserViewModel, ApplicationUser>()
          .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.Name))
          .ForMember(dst => dst.PasswordHash, opt => opt.MapFrom(src => src.Password)) // استخدم PasswordHash
          .ReverseMap();

        }




    }
}
