using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Repositories
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {

        /// <summary>
        /// This is abstracted so that we don't have dependency on db provider at the core
        /// </summary>
        /// <returns></returns>
        public abstract IQueryable<TEntity> GetAll();

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public T Query<T>(Func<IQueryable<TEntity>, T> predicate)
        {
            return predicate(GetAll());
        }

        public TEntity Get(TPrimaryKey id)
        {
            var entity = GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
            if (entity == null)
            {
                throw new ArgumentException("Entity not found");
            }

            return entity;
        }

        public abstract TEntity Insert(TEntity entity);

        public abstract TEntity Update(TEntity entity);

        public abstract void Delete(TPrimaryKey id);

        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

    }
}
