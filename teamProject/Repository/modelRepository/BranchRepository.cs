using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class BranchRepository : RepositoryGeneric<Branch>, IBranchRepository
    {
        public BranchRepository(TeamContext context) : base(context)
        {
        }
    }
}
