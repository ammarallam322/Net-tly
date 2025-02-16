using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class ServiceProviderRepository : RepositoryGeneric<ServiceProvider>, IServiceProviderRepository
    {
        public ServiceProviderRepository(TeamContext context) : base(context)
        {
        }
    }
}
