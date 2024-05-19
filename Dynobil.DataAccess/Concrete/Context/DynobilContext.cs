using Dynobil.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.DataAccess.Concrete.Context
{
    public class DynobilContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<SellingAdvert> SellingAdverts { get; set; }

        public DynobilContext()
        {
            
        }
        public DynobilContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions) 
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JARVIS\\SQLSERVER2022;Database=DynobilTest;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
