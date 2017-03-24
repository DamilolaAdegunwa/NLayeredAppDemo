using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.EntityConfig;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderProduct> SalesOrderProduct { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrderStatus> SalesOrderStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Global settings
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(16, 3));

            RenameIdentitySchema(modelBuilder);
            
            //Per Entity settings
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SalesOrderMap());
            modelBuilder.Configurations.Add(new SalesOrderProductMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new SalesOrderStatusMap());

            
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            this.AddAuditStamps();
            return base.SaveChanges();
        }

        public new DbEntityEntry Entry<TEntity>(TEntity entity) where TEntity: class
        {
            return base.Entry<TEntity>(entity);
        }

        /// <summary>
        /// Automatically set tracking fields such as date modified and user modifed during DbContext.SaveChanges
        /// </summary>
        private void AddAuditStamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x =>
                    (x.Entity is ICreationAudited || x.Entity is IModificationAudited)
                    && (x.State == EntityState.Added || x.State == EntityState.Modified)
                );

            if (!entities.Any())
                return;

            var currentUserName = "";

            if (System.Web.HttpContext.Current != null 
                && System.Web.HttpContext.Current.User != null 
                && System.Web.HttpContext.Current.User.Identity != null
                && System.Web.HttpContext.Current.User.Identity.Name != null)
            {
                currentUserName = System.Web.HttpContext.Current.User.Identity.Name;
            }


            foreach (var entity in entities)
            {
                if (entity.Entity is ICreationAudited && entity.State == EntityState.Added)
                {
                    ((ICreationAudited)entity.Entity).DateCreated = DateTime.UtcNow;
                    ((ICreationAudited)entity.Entity).UserCreated = currentUserName;
                }

                if (entity.Entity is IModificationAudited)
                {
                    ((IModificationAudited)entity.Entity).DateModified = DateTime.UtcNow;
                    ((IModificationAudited)entity.Entity).UserModified = currentUserName;
                }

            }
        }


        /// <summary>
        /// Overrride dbo schema in Identity tables
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void RenameIdentitySchema(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("User", "Security");
            modelBuilder.Entity<IdentityRole>().ToTable("Role", "Security");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole", "Security");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim", "Security");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin", "Security");
        }
    }
}