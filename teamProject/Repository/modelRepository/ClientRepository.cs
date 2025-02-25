using Microsoft.Data.SqlClient;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class ClientRepository : RepositoryGeneric<Client>, IClientRepository
    {
        private readonly IRepositoryGeneric<package> packageRepo;
        private readonly IRepositoryGeneric<Provider_Package> provider_PackageRepo;

        public ClientRepository(TeamContext context ,IRepositoryGeneric<package> packageRepo, IRepositoryGeneric<Provider_Package> Provider_PackageRepo) : base(context)
        {
            this.packageRepo = packageRepo;
            provider_PackageRepo = Provider_PackageRepo;
        }

        public List<package> GetServicePackages(int ServiceId)
        {
           
            var allPackageIds = provider_PackageRepo
                                  .GetAll()
                                  .Where(x => x.provider_Id == ServiceId)
                                  .Select(x => x.Package_Id)
                                  .ToList();

   
            var allPackages = packageRepo
                                  .GetAll()
                                  .Where(p => allPackageIds.Contains(p.Id))
                                  .ToList();

            return allPackages;
        }
    }
}
