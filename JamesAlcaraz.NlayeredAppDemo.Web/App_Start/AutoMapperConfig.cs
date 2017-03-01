using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto.Products;

namespace JamesAlcaraz.NlayeredAppDemo.Web.App_Start
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// This will be used by DI Container
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration GetConfig()
        {
            return new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new ProductProfile());
            });
        }

    }

    public class ProductProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<ProductCreateInput, Product>();
            this.CreateMap<Product, ProductDetailsOutput>();
        }
    }
}