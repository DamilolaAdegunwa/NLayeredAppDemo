using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using Microsoft.AspNet.Identity.EntityFramework;


namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework
{
    public abstract class EntitiesContext : DbContext, IEntitiesContext
    {
        #region constructors
        protected EntitiesContext()
            : base()
        {
        }

        protected EntitiesContext(DbCompiledModel model)
            : base(model)
        {
        }

        public EntitiesContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public EntitiesContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public EntitiesContext(ObjectContext objectContext, bool EntitiesContextOwnsObjectContext)
            : base(objectContext, EntitiesContextOwnsObjectContext)
        {
        }

        public EntitiesContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        public EntitiesContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
        #endregion

        public IdentityDbContext<ApplicationUser> ApplicationUser { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : class
        {

            DbEntityEntry dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = System.Data.Entity.EntityState.Added;
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : class
        {

            DbEntityEntry dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = System.Data.Entity.EntityState.Modified;
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {

            DbEntityEntry dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = System.Data.Entity.EntityState.Deleted;
        }

        // privates
        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : class
        {

            DbEntityEntry dbEntityEntry = base.Entry<TEntity>(entity);
            if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            {

                Set<TEntity>().Attach(entity);
            }

            return dbEntityEntry;
        }
    }
}
