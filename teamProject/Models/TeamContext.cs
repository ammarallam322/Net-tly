using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace teamProject.Models
{
    public class TeamContext : DbContext
    {
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchMobile> BrancheMoblies { get; set; }
        public virtual DbSet<BranchPhone> BranchePhones { get; set; }
        public virtual DbSet<Central> Centrals { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Governerate> Governerates { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<package> Packages { get; set; }
        public virtual DbSet<myServiceProvider> ServiceProviders { get; set; }

        //parameterless consructor that chain on base constructor
        public TeamContext() : base()
        {

        }

        //parameterized consructor that chain on base constructor to prevent exception during configuring

        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Server=DESKTOP-PQBVQ61\\SQLEXPRESS;Database=TeamMVCProject;Trusted_Connection=True; TrustServerCertificate=True;");

        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relation between branch and user (branch manager) ==> [Added By Mohab]
            modelBuilder.Entity<Branch>()
            .HasOne(p => p.Manager)
            .WithMany()
            .HasForeignKey(p => p.Manager_Id)
            .OnDelete(DeleteBehavior.NoAction);

            // Relation between Cleint and ServiceProvider ==> [Added By Mohab]
            //modelBuilder.Entity<Client>()
            //.HasOne(c => c.ServiceProvider)
            //.WithMany(sp => sp.Clients)
            //.HasForeignKey(c => c.Service_Id)
            //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}
