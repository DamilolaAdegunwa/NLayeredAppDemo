﻿using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Specifications;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Interfaces
{
    public interface IProductAppService : IApplicationService
    {
        IEnumerable<ProductGridOutput> GetList();
        ProductDetailsOutput Get(int id);
        ProductDetailsOutput Create(ProductCreateInput productCreateInput);
        void Update(ProductUpdateInput productUpdateInput);
        void Delete(int id);
    }
}
