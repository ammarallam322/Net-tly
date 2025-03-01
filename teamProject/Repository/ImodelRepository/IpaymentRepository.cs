using teamProject.Models;

namespace teamProject.Repository.ImodelRepository
{
    public interface IpaymentRepository
    {

        Task AddPayment(Payment payment);
        Task<List<Payment>> GetAll();

        Task<Payment> GetById(int id);


    }
}
