using teamProject.viewModel;

namespace teamProject.Services
{
    public interface IRecietServicecs
    {
        public ReceitViewModel GetRecietData(int clientId);
        public void Paid(int clientId);
    }

}
