using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;

namespace JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Specifications
{
    /// <summary>
    /// Generic interface for CRUD service
    /// </summary>
    /// <typeparam name="TEntity">The entity</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
    /// <typeparam name="TCreateInputDto">Type of parameter that will be passed on the CREATE method</typeparam>
    /// <typeparam name="TCreateOutputDto">Type of result for the CREATE method</typeparam>
    /// <typeparam name="TUpdateInputDto">Type of parameter that will be passed on the UPDATE method</typeparam>
    public interface ICrudService<TEntity, TPrimaryKey, TCreateInputDto, TCreateOutputDto, TUpdateInputDto>
        where TEntity: class, IEntity<TPrimaryKey>
    {
        TCreateOutputDto Get(TPrimaryKey id);
        TCreateOutputDto Create(TCreateInputDto productCreateInput);
        void Update(TPrimaryKey id, TUpdateInputDto productUpdateInput);
        void Delete(TPrimaryKey id);
    }
}
