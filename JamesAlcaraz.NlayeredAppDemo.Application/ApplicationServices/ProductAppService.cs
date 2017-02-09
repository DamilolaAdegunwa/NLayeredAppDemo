using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Specifications;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;

namespace JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices
{
    public interface IProductAppService : IApplicationService
    {
        ProductOutput CreateProduct(ProductInput productInput);
    }

    public class ProductAppService :  IProductAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _producRepository;

        public ProductAppService(IUnitOfWork unitOfWork, IRepository<Product> producRepository)
        {
            _producRepository = producRepository;
            _unitOfWork = unitOfWork;
        }


        public ProductOutput CreateProduct(ProductInput productInput)
        {
            if (productInput == null)
                throw new ArgumentNullException("Product input cannot be null");
            
            var entity = new Product { Description = productInput.Description };

            var output = _producRepository.Insert(entity);
            _unitOfWork.Commit();

            if (output != null)
                return new ProductOutput{ Id = output.Id, Description = output.Description };
            
            return null;
        }
    }
}
