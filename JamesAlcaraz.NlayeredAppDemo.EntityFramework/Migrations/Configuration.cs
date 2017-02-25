namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Core.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedSalesOrderStatus(context);
        }

        private void SeedSalesOrderStatus(ApplicationDbContext context)
        {
            context.SalesOrderStatus.AddOrUpdate(
                x => x.Id,
                new SalesOrderStatus { Id = 1, Description = "In-Process" },
                new SalesOrderStatus { Id = 2, Description = "Approved" },
                new SalesOrderStatus { Id = 3, Description = "Backordered" },
                new SalesOrderStatus { Id = 4, Description = "Rejected" },
                new SalesOrderStatus { Id = 5, Description = "Shipped" },
                new SalesOrderStatus { Id = 6, Description = "Cancelled" }
            );
        }
    }
}
