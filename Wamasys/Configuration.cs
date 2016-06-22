using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Wamasys.Models.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Wamasys.Models.Values;

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
            // Status
            var status = new List<Status>
            {
                new Status {Name = "New order", Description = "This is a new order"},
                new Status {Name = "Payed", Description = "You have payed."},
                new Status {Name = "Send", Description = "The order is send."},
                new Status {Name = "In progress", Description = "The order is in progress."},
                new Status {Name = "Cancelled", Description = "The order is cancelled."},
                new Status {Name = "Returned", Description = "​The order is returned."},
                new Status {Name = "Delivered", Description = "The order is delivered"}
            };
            // Leveranciers
            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "Plastic & Co", HouseNumber = "23D", City = "Drachten"},
                new Supplier {Name = "Plastic Skynet", HouseNumber = "42", City = "Groningen"},
                new Supplier {Name = "Fabrication Plastic", HouseNumber = "122", City = "Hoogeveen"},
                new Supplier {Name = "Mega Factory", HouseNumber = "12", City = "Emmen"},
                new Supplier {Name = "Plastic Incorporate", HouseNumber = "73", City = "Assen"},
                new Supplier {Name = "123Fabriek", HouseNumber = "23", City = "Leeuwarden"},
                new Supplier {Name = "Nintendo Plastic", HouseNumber = "44", City = "Detroid"},
                new Supplier {Name = "Promich Plastic", HouseNumber = "98", City = "Lelystad"},
                new Supplier {Name = "Megacorp", HouseNumber = "42", City = "Echten"},
                new Supplier {Name = "Discount Plastic", HouseNumber = "22", City = "Haren"}
            };

            // Stores
            // Een store heeft nu alleen een naam en een stad. Eerst maar eens wat lui maken.
            var storeNames = new StoreNames();
            var stores = new List<Company> { };
            for (int i = 0; i < 630; i++)
            {
                String storeName = storeNames.getNewStore();
                String[] arrayStorename = storeName.Split(null);
                stores.Add(new Company { Name = storeName, City = arrayStorename[1] });
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            if (roleManager.FindByName(RoleModel.Admin) == null)
            {
                roleManager.Create(new ApplicationRole { Name = RoleModel.Admin, Type = RoleType.Elevated });
                roleManager.Create(new ApplicationRole { Name = RoleModel.Customer, Type = RoleType.Customer });
                roleManager.Create(new ApplicationRole { Name = RoleModel.Supplier, Type = RoleType.Supplier });
            }
            var user1 = new ApplicationUser { FirstName = "Michael", LastName = "veen der Van", Email = "spammich@live.nl", EmailConfirmed = true, UserName = "spammich@live.nl", AccessFailedCount = 0 };
            var user2 = new ApplicationUser { FirstName = "Joost", LastName = "de Grote", Email = "pipodeclown@st.hanze.nl", EmailConfirmed = true, UserName = "pipodeclown@st.hanze.nl", AccessFailedCount = 0 };
            var user3 = new ApplicationUser { FirstName = "Leon", LastName = "van der Wetzel", Email = "leonW@st.hanze.nl", EmailConfirmed = true, UserName = "leonW@st.hanze.nl", AccessFailedCount = 0 };
            var user4 = new ApplicationUser { FirstName = "Leonie", LastName = "van der Wetzel", Email = "leonieW@st.hanze.nl", EmailConfirmed = true, UserName = "leonieW@st.hanze.nl", AccessFailedCount = 0 };
            var user5 = new ApplicationUser { FirstName = "Jörgen", LastName = "Goos", Email = "jorgen.goos@getthere.com", EmailConfirmed = true, UserName = "jorgen.goos@getthere.com", AccessFailedCount = 0 };

            userManager.Create(user1, "test123");
            userManager.Create(user2, "test123");
            userManager.Create(user3, "test123");
            userManager.Create(user4, "test123");
            userManager.Create(user5, "test123");

            var adminRole = context.Roles.FirstOrDefault(row => row.Name == RoleModel.Admin)?.Id;
            var customerRole = context.Roles.FirstOrDefault(row => row.Name == RoleModel.Customer)?.Id;
            var supplierRole = context.Roles.FirstOrDefault(row => row.Name == RoleModel.Supplier)?.Id;

            var userRole1 = new IdentityUserRole { RoleId = adminRole, UserId = user1.Id };
            var userRole2 = new IdentityUserRole { RoleId = customerRole, UserId = user2.Id };
            var userRole3 = new IdentityUserRole { RoleId = supplierRole, UserId = user3.Id };
            var userRole4 = new IdentityUserRole { RoleId = supplierRole, UserId = user4.Id };
            var userRole5 = new IdentityUserRole { RoleId = supplierRole, UserId = user5.Id };

            user1.Roles.Add(userRole1);
            user2.Roles.Add(userRole2);
            user3.Roles.Add(userRole3);
            user4.Roles.Add(userRole4);
            user5.Roles.Add(userRole5);


        }

    }
}