using teamProject.Models;

namespace teamProject.Repository.ImodelRepository
{
    public interface IClientRepository
    {
        public List<package> GetServicePackages(int ServiceId);
        public List<Offer> GetOfferService(int ServiceId);
        
    }
}
