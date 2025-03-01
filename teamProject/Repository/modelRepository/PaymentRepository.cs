using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository.modelRepository
{
    public class PaymentRepository : IpaymentRepository
    {
        private TeamContext context;

        public PaymentRepository(TeamContext context)
        {
            this.context = context;
        }

        public async Task AddPayment(Payment payment)
        {
          await  context.Payment.AddAsync(payment);
            await context.SaveChangesAsync();
        }

        public async Task<List <Payment>> GetAll()
        {
            return await context.Payment.ToListAsync();
        }

        public  async Task<Payment> GetById(int id)
        {
          return  await context.Payment.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
