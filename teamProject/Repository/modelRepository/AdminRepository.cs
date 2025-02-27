using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository.modelRepository
{
    public class AdminRepository : RepositoryGeneric<Admin>, IAdminRepository
    {
        public AdminRepository(TeamContext context) : base(context)
        {
        }
    }
}
