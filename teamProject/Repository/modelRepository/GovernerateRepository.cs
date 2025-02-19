using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class GovernerateRepository : RepositoryGeneric<Governerate>, IGovernerateRepository
    {
        public GovernerateRepository(TeamContext context) : base(context)
        {
        }
    }
}
