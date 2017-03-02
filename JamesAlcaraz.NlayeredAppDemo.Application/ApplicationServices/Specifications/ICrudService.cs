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
    /// <summary>
    /// Generic interface for CRUD service
    /// </summary>
    /// <typeparam name="TEntity">The entity</typeparam>
    /// <typeparam name="TCreateInputDto">Type of parameter that will be passed on the CREATE method</typeparam>
    /// <typeparam name="TCreateOutputDto">Type of result for the CREATE method</typeparam>
    /// <typeparam name="TUpdateInputDto">Type of parameter that will be passed on the UPDATE method</typeparam>
    public interface ICrudService<TEntity, TCreateInputDto, TCreateOutputDto, TUpdateInputDto> 
        : ICrudService<TEntity, int, TCreateInputDto, TCreateOutputDto, TUpdateInputDto>
        where TEntity: class, IEntity<int>
    {

    }
}
