using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.RepositoryImplementation
{
    public class EFRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IEntitiesContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        public EFRepositoryBase(IEntitiesContext dbContext)
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
            var test = _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return test;
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
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public override void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
