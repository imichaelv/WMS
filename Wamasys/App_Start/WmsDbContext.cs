using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wamasys.Models.Database;

namespace Wamasys
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>//DbContext
    {


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