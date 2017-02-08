using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.Repositories
{
    public class EFRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        public EFRepositoryBase(IApplicationDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Db context is null");

            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public override IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public override TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public override void Delete(TEntity entity)
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public override void Update(TEntity entity)
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        private DbEntityEntry GetDbEntityEntrySafely(TEntity entity)
        {
            var dbEntityEntry = _dbContext.Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            return dbEntityEntry;
        }

    }
}
