using AutoMapper;
using teamProject.MapConfig;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;
using teamProject.viewModel;

namespace teamProject.Services
{
    public class PaymentSevice : IPaymentSevice
    {
        IpaymentRepository paymentRepository;
        IMapper mapper;

        public PaymentSevice(IpaymentRepository paymentRepository, IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        public async Task<List<PaymentViewModel>> GetAll()
        {
           return mapper.Map<List<PaymentViewModel>>(await paymentRepository.GetAll());
        }

        public async Task<PaymentViewModel> GetById(int id)
        {
            //getting from db andmapping
            return  mapper.Map<PaymentViewModel> (  await paymentRepository.GetById(id));
        }

        public async Task<bool> ProcessPayment(PaymentViewModel paymentVM)
        {
            if (paymentVM == null)
            {
                return false; 
            }

            try
            {
                var paymentEntity = mapper.Map<Payment>(paymentVM);

                await paymentRepository.AddPayment(paymentEntity);


                return true;                         
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
