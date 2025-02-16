using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class packageRepository : RepositoryGeneric<package>, IpackageRepository
    {
        public packageRepository(TeamContext context) : base(context)
        {
        }
    }
}
