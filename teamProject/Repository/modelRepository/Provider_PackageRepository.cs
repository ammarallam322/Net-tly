using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{

    public class Provider_PackageRepository : RepositoryGeneric<Provider_Package>, IProvider_PackageRepository
    {
        public Provider_PackageRepository(TeamContext context) : base(context)
        {
        }
    }
}
