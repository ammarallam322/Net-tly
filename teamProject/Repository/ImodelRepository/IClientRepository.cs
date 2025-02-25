using teamProject.Models;

namespace teamProject.Repository.ImodelRepository
{
    public interface IClientRepository
    {
        public List<package> GetServicePackages(int ServiceId);
    }
}
