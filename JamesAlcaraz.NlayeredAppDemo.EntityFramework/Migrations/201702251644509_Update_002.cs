namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_002 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "Lookup.SalesOrderStatus", newSchema: "Lookups");
        }
        
        public override void Down()
        {
            MoveTable(name: "Lookups.SalesOrderStatus", newSchema: "Lookup");
        }
    }
}
