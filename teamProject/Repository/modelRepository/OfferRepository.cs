using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using teamProject.Models;
using teamProject.Repository;
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
