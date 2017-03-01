using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;

namespace JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Specifications
{
    public abstract class CrudServiceBase<TEntity, TCreateInputDto, TCreateOutputDto, TUpdateInputDto> 
        : CrudServiceBase<TEntity, int, TCreateInputDto, TCreateOutputDto, TUpdateInputDto>
        where TEntity : class, IEntity<int>
    {
        public CrudServiceBase(IRepository<TEntity, int> repository, IUnitOfWork unitOfWork, IMapper mapper)
            :base(repository, unitOfWork, mapper)
        {

        }
    }
}
