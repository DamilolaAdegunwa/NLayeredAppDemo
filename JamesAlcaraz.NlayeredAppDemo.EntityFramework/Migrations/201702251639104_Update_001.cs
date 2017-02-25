namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_001 : DbMigration
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
                .ForeignKey("Lookup.SalesOrderStatus", t => t.StatusId, cascadeDelete: true)
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
                "Lookup.SalesOrderStatus",
                c => new
                    {
                        Id = c.Short(nullable: false),
                        Description = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Products.Product", "UnitPrice", c => c.Decimal(nullable: false, precision: 16, scale: 3));
            AlterColumn("Products.Product", "Description", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("Sales.SalesOrder", "StatusId", "Lookup.SalesOrderStatus");
            DropForeignKey("Sales.SalesOrderProduct", "SalesOrderId", "Sales.SalesOrder");
            DropForeignKey("Sales.SalesOrderProduct", "ProductId", "Products.Product");
            DropForeignKey("Sales.SalesOrder", "CustomerId", "Customers.Customer");
            DropIndex("Sales.SalesOrderProduct", new[] { "ProductId" });
            DropIndex("Sales.SalesOrderProduct", new[] { "SalesOrderId" });
            DropIndex("Sales.SalesOrder", new[] { "CustomerId" });
            DropIndex("Sales.SalesOrder", new[] { "StatusId" });
            AlterColumn("Products.Product", "Description", c => c.String());
            DropColumn("Products.Product", "UnitPrice");
            DropTable("Lookup.SalesOrderStatus");
            DropTable("Sales.SalesOrderProduct");
            DropTable("Sales.SalesOrder");
            DropTable("Customers.Customer");
        }
    }
}
