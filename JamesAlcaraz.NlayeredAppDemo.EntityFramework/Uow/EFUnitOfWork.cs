using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.Uow
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public EFUnitOfWork(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public int Commit()
        {
            return _applicationDbContext.SaveChanges();
        }
    }
}
