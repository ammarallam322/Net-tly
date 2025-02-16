using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository
{
    public class OfferRepository : RepositoryGeneric<Offer>, IOfferRepository
    {
        public OfferRepository(TeamContext context) : base(context)
        {
        }
    }
}
