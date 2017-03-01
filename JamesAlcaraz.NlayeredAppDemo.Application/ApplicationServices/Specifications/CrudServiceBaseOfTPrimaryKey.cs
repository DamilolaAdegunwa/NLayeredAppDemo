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
    public abstract class CrudServiceBase<TEntity, TPrimaryKey, TCreateInputDto, TCreateOutputDto, TUpdateInputDto> : ICrudService<TEntity, TPrimaryKey, TCreateInputDto, TCreateOutputDto, TUpdateInputDto>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        public CrudServiceBase(IRepository<TEntity,TPrimaryKey> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public TCreateOutputDto Get(TPrimaryKey id)
        {
            TEntity entity = Repository.FindById(id);

            if (entity == null)
                throw new NullReferenceException("Entity not found");

            return Mapper.Map<TEntity, TCreateOutputDto>(entity);
        }

        public TCreateOutputDto Create(TCreateInputDto inputDto)
        {
            if (inputDto == null)
                throw new ArgumentNullException("Input parameter cannot be null");

            var entity = Mapper.Map<TEntity>(inputDto);
            Repository.Insert(entity);
            UnitOfWork.Commit();
            return Mapper.Map<TCreateOutputDto>(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            TEntity entity = Repository.FindById(id);

            if (entity == null)
                throw new ArgumentNullException("Entity not found");

            Repository.Delete(entity);
            UnitOfWork.Commit();
        }



        public void Update(TPrimaryKey id, TUpdateInputDto inputDto)
        {
            if (inputDto == null)
                throw new ArgumentNullException("Input DTO cannot be null");

            var entity = Repository.FindById(id);

            Repository.Update(entity);
            UnitOfWork.Commit();
        }
    }
}
