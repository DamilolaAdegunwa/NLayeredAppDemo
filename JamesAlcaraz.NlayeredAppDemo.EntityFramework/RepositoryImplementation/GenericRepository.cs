using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.RepositoryImplementation
{
    public class GenericRepository<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IEntitiesContext _dbContext;

        public GenericRepository(IEntitiesContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Db context is null");

            _dbContext = dbContext;
        }

        public override IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public override TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }


        

        public override TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
