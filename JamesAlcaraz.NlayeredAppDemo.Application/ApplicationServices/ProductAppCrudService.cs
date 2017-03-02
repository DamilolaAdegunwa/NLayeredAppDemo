using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Specifications;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto.Products;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;

namespace JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices
{
    public class ProductAppCrudService : CrudServiceBase<Product, ProductCreateInput, ProductDetailsOutput, ProductUpdateInput>
    {
        public ProductAppCrudService(IRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(repository, unitOfWork, mapper)
        {
            
        }
    }
}
