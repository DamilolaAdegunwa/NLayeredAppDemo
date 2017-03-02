using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Interfaces;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Specifications;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto.Products;
using JamesAlcaraz.NlayeredAppDemo.Application.InfrastructureServices.Authentication;
using JamesAlcaraz.NlayeredAppDemo.Application.Mappings;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.Repositories;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework.Uow;
using JamesAlcaraz.NlayeredAppDemo.WebApi.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;


namespace JamesAlcaraz.NlayeredAppDemo.WebApi.App_Start
{
    public class IocContainer
    {
        public static ContainerBuilder GetBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //ASP.Net Identity Services
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationDbContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("NLayeredAppDemo​")
            });
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerRequest();

            //Generic Repositories
            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().InstancePerRequest();
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<EFRepositoryBase<Product>>().As<IRepository<Product>>().InstancePerRequest();
            builder.RegisterType<ProductAppService>().As<IProductAppService>().InstancePerRequest();
            builder.RegisterInstance(AutoMapperConfig.GetConfig().CreateMapper()).As<IMapper>();


            //Register AuthorizationServerProvider in the root scope for Owin Startup use
            builder.RegisterType<AuthorizationServerProvider>().As<IOAuthAuthorizationServerProvider>().SingleInstance();

            return builder;
        }
    }
}