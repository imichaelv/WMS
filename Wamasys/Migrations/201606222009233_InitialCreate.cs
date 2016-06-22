namespace Wamasys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiKeys",
                c => new
                    {
                        ApiKeyId = c.Guid(nullable: false),
                        SecretKey = c.String(),
                        Disabled = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ApiKeyId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.SupplierId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        HouseNumber = c.String(),
                        Director = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        CustomerOrderid = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerOrderid)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        GantryId = c.Int(nullable: false),
                        CustomerOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.CustomerOrders", t => t.CustomerOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Gantries", t => t.GantryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.GantryId)
                .Index(t => t.CustomerOrderId);
            
            CreateTable(
                "dbo.Gantries",
                c => new
                    {
                        GantryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Limit = c.Int(nullable: false),
                        XCoordinate = c.Int(nullable: false),
                        YCoordinate = c.Int(nullable: false),
                        ZCoordinate = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GantryId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        HouseNumber = c.Int(nullable: false),
                        XCoordinate = c.Int(nullable: false),
                        YCoordinate = c.Int(nullable: false),
                        ZCoordinate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        MinimumAmount = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HouseNumber = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.SupplierOrders",
                c => new
                    {
                        SupplierOrderId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierOrderId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.SupplierOrders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.SupplierOrders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CustomerOrders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.AspNetUsers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Items", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Items", "GantryId", "dbo.Gantries");
            DropForeignKey("dbo.Gantries", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Items", "CustomerOrderId", "dbo.CustomerOrders");
            DropForeignKey("dbo.CustomerOrders", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApiKeys", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.SupplierOrders", new[] { "ProductId" });
            DropIndex("dbo.SupplierOrders", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Gantries", new[] { "BuildingId" });
            DropIndex("dbo.Items", new[] { "CustomerOrderId" });
            DropIndex("dbo.Items", new[] { "GantryId" });
            DropIndex("dbo.Items", new[] { "ProductId" });
            DropIndex("dbo.CustomerOrders", new[] { "StatusId" });
            DropIndex("dbo.CustomerOrders", new[] { "CompanyId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "SupplierId" });
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropIndex("dbo.ApiKeys", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.SupplierOrders");
            DropTable("dbo.Status");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Buildings");
            DropTable("dbo.Gantries");
            DropTable("dbo.Items");
            DropTable("dbo.CustomerOrders");
            DropTable("dbo.Companies");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ApiKeys");
        }
    }
}
