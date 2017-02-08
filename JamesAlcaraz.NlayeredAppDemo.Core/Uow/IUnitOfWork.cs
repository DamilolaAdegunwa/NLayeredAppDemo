using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Uow
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
