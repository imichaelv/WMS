using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.AspNet.Identity;
using Wamasys.Migrations;
using Wamasys.Models.Database;
using Wamasys.Models.Values;

namespace Wamasys
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>//DbContext
    {
        private static readonly Random Rand = new Random();
        private static readonly char[] Alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };

        public DbSet<Building> Building { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<Gantry> Gantry { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierOrder> SupplierOrder { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

        public ApplicationDbContext() : base("wamasysdb1")
        {

        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public static void Seed(ApplicationDbContext context)
        {
          
        }
    }
}