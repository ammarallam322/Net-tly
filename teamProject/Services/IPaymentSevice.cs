using teamProject.viewModel;

namespace teamProject.Services
{
    public interface IPaymentSevice
    {


       Task< bool> ProcessPayment(PaymentViewModel payment);

        Task<List <PaymentViewModel>> GetAll();


        Task <PaymentViewModel> GetById(int id);    


    }
}
