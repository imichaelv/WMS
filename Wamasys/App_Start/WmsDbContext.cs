using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wamasys.Models.Database;

namespace Wamasys
{
    public class WmsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>//DbContext
    {


        public static WmsDbContext Create()
        {
            return new WmsDbContext();
        }


        public static void Seed(WmsDbContext wmsDbContext)
        {
            throw new System.NotImplementedException();
        }
    }
}