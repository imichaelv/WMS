using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wamasys.Models.Database;

namespace Wamasys
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>//DbContext
    {

        public DbSet<Building>          Building { get; set; }
        public DbSet<Company>           Company { get; set; }
        public DbSet<CustomerOrder>     CustomerOrder { get; set; }
        public DbSet<Gantry>            Gantry { get; set; }
        public DbSet<Item>              Item { get; set; }
        public DbSet<Product>           Product { get; set; }
        public DbSet<Status>            Status { get; set; }
        public DbSet<Supplier>          Supplier { get; set; }
        public DbSet<SupplierOrder>     SupplierOrder { get; set; }

        public ApplicationDbContext() : base("databasenaam")
        {
            
        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public static void Seed(ApplicationDbContext wmsDbContext)
        {
            //throw new System.NotImplementedException();
        }
    }
}