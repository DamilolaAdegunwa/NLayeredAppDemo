using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto.Products;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;

namespace JamesAlcaraz.NlayeredAppDemo.Application.Mappings
{
    public class ProductProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<ProductCreateInput, Product>();
            this.CreateMap<Product, ProductDetailsOutput>();
        }
    }
}
