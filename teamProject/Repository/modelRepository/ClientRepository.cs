using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class ClientRepository : RepositoryGeneric<Client>, IClientRepository
    {
        public ClientRepository(TeamContext context) : base(context)
        {
        }
    }
}
