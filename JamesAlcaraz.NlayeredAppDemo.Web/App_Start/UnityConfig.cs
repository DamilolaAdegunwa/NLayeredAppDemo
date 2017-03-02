using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Interfaces;
using JamesAlcaraz.NlayeredAppDemo.Application.Mappings;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.Repositories;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.Uow;
using JamesAlcaraz.NlayeredAppDemo.Web.App_Start;
using JamesAlcaraz.NlayeredAppDemo.Web.Controllers;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace JamesAlcaraz.NlayeredAppDemo.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IApplicationDbContext, ApplicationDbContext>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, EFUnitOfWork>();

            container.RegisterType<IRepository<Product, int>, EFRepositoryBase<Product, int>>();
            container.RegisterType<IRepository<Product>, EFRepositoryBase<Product>>();

            container.RegisterType<IProductAppService, ProductAppService>();

            container.RegisterInstance<IMapper>(AutoMapperConfig.GetConfig().CreateMapper());

            //Force unity to use the parameter less constructor for Security Related Controllers
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }
    }
}