namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Customers.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Sales.SalesOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DueDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ShipDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        StatusId = c.Short(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(precision: 7, storeType: "datetime2"),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Customers.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("Lookups.SalesOrderStatus", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "Sales.SalesOrderProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        QuantityOrdered = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 16, scale: 3),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(precision: 7, storeType: "datetime2"),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Products.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Sales.SalesOrder", t => t.SalesOrderId, cascadeDelete: true)
                .Index(t => t.SalesOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Products.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 128),
                        UnitPrice = c.Decimal(nullable: false, precision: 16, scale: 3),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(precision: 7, storeType: "datetime2"),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookups.SalesOrderStatus",
                c => new
                    {
                        Id = c.Short(nullable: false),
                        Description = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Security.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "Security.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Security.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Security.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Security.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Security.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Security.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Security.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Security.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Security.UserRole", "UserId", "Security.User");
            DropForeignKey("Security.UserLogin", "UserId", "Security.User");
            DropForeignKey("Security.UserClaim", "UserId", "Security.User");
            DropForeignKey("Security.UserRole", "RoleId", "Security.Role");
            DropForeignKey("Sales.SalesOrder", "StatusId", "Lookups.SalesOrderStatus");
            DropForeignKey("Sales.SalesOrderProduct", "SalesOrderId", "Sales.SalesOrder");
            DropForeignKey("Sales.SalesOrderProduct", "ProductId", "Products.Product");
            DropForeignKey("Sales.SalesOrder", "CustomerId", "Customers.Customer");
            DropIndex("Security.UserLogin", new[] { "UserId" });
            DropIndex("Security.UserClaim", new[] { "UserId" });
            DropIndex("Security.User", "UserNameIndex");
            DropIndex("Security.UserRole", new[] { "RoleId" });
            DropIndex("Security.UserRole", new[] { "UserId" });
            DropIndex("Security.Role", "RoleNameIndex");
            DropIndex("Sales.SalesOrderProduct", new[] { "ProductId" });
            DropIndex("Sales.SalesOrderProduct", new[] { "SalesOrderId" });
            DropIndex("Sales.SalesOrder", new[] { "CustomerId" });
            DropIndex("Sales.SalesOrder", new[] { "StatusId" });
            DropTable("Security.UserLogin");
            DropTable("Security.UserClaim");
            DropTable("Security.User");
            DropTable("Security.UserRole");
            DropTable("Security.Role");
            DropTable("Lookups.SalesOrderStatus");
            DropTable("Products.Product");
            DropTable("Sales.SalesOrderProduct");
            DropTable("Sales.SalesOrder");
            DropTable("Customers.Customer");
        }
    }
}
