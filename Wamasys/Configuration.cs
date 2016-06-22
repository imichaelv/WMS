using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Wamasys.Models.Database;

namespace Wamasys.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Leveranciers
            var leveranciers = new List<Supplier>
            {
                new Supplier {Name = "Fabriek Groningen", HouseNumber = "515", City = "Groningen"};
            }
        }
    }    
}