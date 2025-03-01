using AutoMapper;
using teamProject.Models;
using teamProject.viewModel;

namespace teamProject.MapConfig
{
    public class PaymentConfig : Profile
    {


        public PaymentConfig()
        {
            CreateMap<Payment, PaymentViewModel>().AfterMap((src, dist) => { }).ReverseMap();

        }



    }
}
