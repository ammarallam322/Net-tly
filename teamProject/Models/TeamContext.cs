using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace teamProject.Models
{
    public class TeamContext : DbContext
    {

        public virtual DbSet<Branch> Branches { get; set; }


        public virtual DbSet<Central> Centrals { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Governerate> Governerates { get; set; }

        public virtual DbSet<Offer> Offers { get; set; }


        public virtual DbSet<package> Packages { get; set; }
        public virtual DbSet<ServiceProviderRepository> ServiceProviders { get; set; }





        //parameterless consructor that chain on base constructor
        public TeamContext() : base()
        {

        }

        //parameterized consructor that chain on base constructor to prevent exception during configuring

        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-PQBVQ61\\SQLEXPRESS;Database=TeamMVCProject;Trusted_Connection=True; TrustServerCertificate=True;");

        }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }






    }
}
