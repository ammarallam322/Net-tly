using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class CentralRepository : RepositoryGeneric<Central>, ICentralRepository
    {
        public CentralRepository(TeamContext context  ) : base(context)
        {
        }
    }
}
