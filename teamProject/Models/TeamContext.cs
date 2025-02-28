using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using teamProject.viewModel;

namespace teamProject.Models
{
    public class TeamContext : IdentityDbContext<ApplicationUser>
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
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }



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

        //    optionsBuilder.UseSqlServer("Server=DESKTOP-FRBH0T7\\SQLEXPRESS;Database=TeamMVCProject;Trusted_Connection=True; TrustServerCertificate=True;");

        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Branch>()
           .HasOne(b => b.Manager)
           .WithMany(m => m.ManagedBranches) 
           .HasForeignKey(b => b.Manager_Id)
           .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicationUser>()
            .HasOne(b => b.Branch)
            .WithMany(u => u.Employees)
            .HasForeignKey(u => u.BranchId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
