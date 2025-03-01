using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using teamProject.MapConfig;
using teamProject.Models;
using teamProject.Repository;
using teamProject.Repository.ImodelRepository;
using teamProject.Services;

namespace teamProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //register of context
            builder.Services.AddDbContext<TeamContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });

            //adding mapper
            builder.Services.AddAutoMapper(typeof(PackageConfig));

            builder.Services.AddControllersWithViews();

            //register of generic repository
            builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            builder.Services.AddScoped(typeof(IRepositoryGeneric<Client>), typeof(RepositoryGeneric<Client>));
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IRecietServicecs, RecietServicecs>();



            // regester of identity and simplyfing password constraints
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<TeamContext>().AddDefaultTokenProviders(); 

            ////mona
            //builder.Services.AddDbContext<TeamContext>(options =>options.UseSqlServer("Your_Connection_String"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            // setting  login as default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=branch}/{action=index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
