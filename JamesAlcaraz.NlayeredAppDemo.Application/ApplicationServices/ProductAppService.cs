using System;
using System.Collections.Generic;
using System.Linq;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Interfaces;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories.PagedList;
using AutoMapper;

namespace JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices
{
    public class ProductAppService :  IProductAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _producRepository;
        private readonly IMapper _mapper;

        public ProductAppService(IUnitOfWork unitOfWork, 
            IRepository<Product> producRepository,
            IMapper mapper)
        {
            _producRepository = producRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ProductGridOutput> GetList()
        {
            var output = from p in _producRepository.GetAll()
                         select new ProductGridOutput
                         {
                             Id = p.Id,
                             Description = p.Description
                         };
            return output;
        }

        public IPagedList<ProductGridOutput> GetPagedList(int pageNumber, int pageSize)
        {
            var output = GetList().ToPagedList(pageNumber, pageSize);
            return output;
        }

        public ProductDetailsOutput Get(int id)
        {
            Product entity = _producRepository.FindById(id);

            if (entity == null)
                throw new NullReferenceException("Product not found");

            return _mapper.Map<Product, ProductDetailsOutput>(entity);
        }

        public ProductDetailsOutput Create(ProductCreateInput productCreateInput)
        {
            if (productCreateInput == null)
                throw new ArgumentNullException("Product input cannot be null");
            
            var entity = new Product { Description = productCreateInput.Description };

            var output = _producRepository.Insert(entity);
            _unitOfWork.Commit();

            if (output != null)
                return _mapper.Map<Product, ProductDetailsOutput>(entity);
            
            return null;
        }

        public void Update(ProductUpdateInput productUpdateInput)
        {
            if (productUpdateInput == null)
                throw new ArgumentNullException("Product input cannot be null");

            var entity = _producRepository.FindById(productUpdateInput.Id);

            entity.Description = productUpdateInput.Description;

            _producRepository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            Product entity = _producRepository.FindById(id);

            if (entity == null)
                throw new ArgumentNullException("Product not found");

            _producRepository.Delete(entity);
            _unitOfWork.Commit();
        }




    }
}
