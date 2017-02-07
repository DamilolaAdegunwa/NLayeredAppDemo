using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IEntitiesContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        #region IEntitiesContext
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : class
        {
            DbEntityEntry dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = EntityState.Added;
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : class
        {
            DbEntityEntry dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            DbEntityEntry dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
        #endregion

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : class
        {

            DbEntityEntry dbEntityEntry = base.Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }

            return dbEntityEntry;
        }
    }
}