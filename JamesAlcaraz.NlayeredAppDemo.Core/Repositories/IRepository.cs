using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        //Collections
        IQueryable<TEntity> GetAll();
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        //Get single
        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);
        TEntity Get(TPrimaryKey id);

        //Destructive operations
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TPrimaryKey id);
    }
}
