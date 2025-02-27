using teamProject.Models;
using teamProject.viewModel.Branch;

namespace teamProject.Repository.ImodelRepository
{
    public interface IBranchRepository : IRepositoryGeneric<Branch>
    {
        public Branch GetBranchWithMobPhnById(int id);
        public Branch GetBranchWithMobPhnById(BranchEditViewModel branch, int id);
        public int GetCount();
        public IQueryable<BranchPhMobViewModel> GetPagination();
    }
}
