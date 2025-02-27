using teamProject.Models;
using teamProject.viewModel.Branch;

namespace teamProject.Repository.modelRepository
{
    public class BranchPhonRepositry : RepositoryGeneric<BranchPhone>
    {
        public BranchPhonRepositry(TeamContext context) : base(context)
        {

        }
    }
}
