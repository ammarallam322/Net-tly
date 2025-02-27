using teamProject.Models;
using teamProject.viewModel.Branch;

namespace teamProject.Repository.modelRepository
{
    public class BranchMobRepositry : RepositoryGeneric<BranchMobile>
    {
        public BranchMobRepositry(TeamContext context) : base(context)
        {
        }
    }
}
