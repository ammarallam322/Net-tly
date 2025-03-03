using Microsoft.Data.SqlClient;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class ClientRepository : RepositoryGeneric<Client>, IClientRepository
    {
        private readonly IRepositoryGeneric<package> packageRepo;
        private readonly IRepositoryGeneric<Offer> offerRepo;
        private readonly IRepositoryGeneric<Provider_Package> provider_PackageRepo;

        public ClientRepository(TeamContext context, IRepositoryGeneric<package> packageRepo, IRepositoryGeneric<Provider_Package> Provider_PackageRepo , IRepositoryGeneric<Offer> offerRepo) : base(context)
        {
            this.packageRepo = packageRepo;
            this.offerRepo = offerRepo;
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

        public List<Offer> GetOfferService(int ServiceId)
        {

           var AllOfferPackages = offerRepo.GetAll()
                .Where(x => x.Servuce_Id == ServiceId).ToList();
           
            return AllOfferPackages;
        }

        public Client GetClientByPhone(string phone)
        {
            return GetAll().FirstOrDefault(x => x.Phone == phone);
        }
    }
}
