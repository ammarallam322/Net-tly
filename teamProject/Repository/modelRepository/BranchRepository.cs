using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;
using teamProject.viewModel.Branch;
using static Dapper.SqlMapper;

namespace teamProject.Repository
{
    public class BranchRepository : RepositoryGeneric<Branch>, IBranchRepository
    {
        public BranchRepository(TeamContext context) : base(context)
        {
        }

        public Branch GetBranchWithMobPhnById(int id)
        {
            return context.Branches
                  .Include(b => b.BranchMobiles)
                  .Include(b => b.BranchPhones)
                  .FirstOrDefault(b => b.Id == id);
        }

        public Branch GetBranchWithMobPhnById(BranchEditViewModel branch, int id)
        {
            return context.Branches.FirstOrDefault(b => b.Manager_Id == branch.Manager_Id && b.Id != id);
        }

        public int GetCount()
        {
            return context.Branches.Count();
        }

        public IQueryable<BranchPhMobViewModel> GetPagination()
        {
            return context.Branches.Select(b => new BranchPhMobViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Address = b.Address,
                Mobile1 = b.BranchMobiles.Br_Mob1,
                Mobile2 = b.BranchMobiles.Br_Mob1,
                Phone1 = b.BranchPhones.Br_Ph1,
                Phone2 = b.BranchPhones.Br_Ph1,
                Fax = b.Fax,
                ManagerName = b.Manager != null ? b.Manager.UserName : "N/A"
            });
        }
    }
}
