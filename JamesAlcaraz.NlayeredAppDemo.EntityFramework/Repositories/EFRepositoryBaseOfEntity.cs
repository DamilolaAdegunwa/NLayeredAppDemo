using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.Repositories
{
    public class EFRepositoryBase<TEntity> 
        : EFRepositoryBase<TEntity, int>, IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        public EFRepositoryBase(IApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            
        }
    }
}
